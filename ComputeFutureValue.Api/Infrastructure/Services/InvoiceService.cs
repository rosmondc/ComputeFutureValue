using AutoMapper;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Common.Entities;
using ComputeFutureValue.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<InvoiceHistory> _repository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<InvoiceHistory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public decimal CalculateFutureAmount(InvoiceViewModel model)
        {
            decimal futureValue = 0;
            decimal interestRate = 0;
            for (int i = 0; i < model.Maturity; i++)
            {
                decimal runningTotal;
                if (i == 0)
                {
                    interestRate = model.LowerBoundInterestRate;
                    runningTotal = model.PresentValue;
                }
                else
                {
                    runningTotal = futureValue;
                    interestRate += model.IncrementaltRate;

                    if (interestRate > model.UpperBoundInterestRate)
                        interestRate -= model.IncrementaltRate;
                }

                futureValue = (runningTotal * (interestRate / 100)) + runningTotal;
            }

            model.FutureValue = futureValue;

            return (futureValue > 0) ? futureValue : 0;
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetAllHistory()
        {
            return _mapper.Map<IEnumerable<InvoiceViewModel>>(await _repository.GetAll());
        }

        public async Task<bool> SaveInvoiceComputation(InvoiceViewModel model)
        {
            var history = _mapper.Map<InvoiceHistory>(model);
            var result = await _repository.AddAsync(history);

            return (result != null);
        }
    }

}
