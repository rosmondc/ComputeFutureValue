using AutoMapper;
using ComputeFutureValue.Api.Data.Entities;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.ViewModel;
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

        public async Task<decimal> CalculateFutureAmount(InvoiceHistoryViewModel model)
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

            var result = await SaveComputation(model);

            if (result)
                return futureValue;

            return 0;
        }

        public async Task<IEnumerable<InvoiceHistoryViewModel>> GetAllHistory()
        {
            return _mapper.Map<IEnumerable<InvoiceHistoryViewModel>>(await _repository.GetAll());
        }

        private async Task<bool> SaveComputation(InvoiceHistoryViewModel model)
        {
            var history = _mapper.Map<InvoiceHistory>(model);
            var result = await _repository.AddAsync(history);

            if (result != null)
                return true;

            return false;
        }
    }

}
