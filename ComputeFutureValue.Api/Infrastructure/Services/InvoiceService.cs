using AutoMapper;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Common.Entities;
using ComputeFutureValue.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
                    interestRate += model.IncrementalRate;

                    if (interestRate > model.UpperBoundInterestRate)
                        interestRate -= model.IncrementalRate;
                }

                futureValue = (runningTotal * (interestRate / 100)) + runningTotal;
            }

            model.FutureValue = futureValue;

            return (futureValue > 0) ? futureValue : 0;
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetAllHistory(string sortOrder)
        {
            var results = await _repository.GetAll();

            if (sortOrder == "presentValue")
                results = results.OrderBy(x => x.PresentValue).ToList();
            else if (sortOrder == "presentValue_desc")
                results = results.OrderByDescending(x => x.PresentValue).ToList();
            else if (sortOrder == "lowerBoundInterestRate")
                results = results.OrderBy(x => x.LowerBoundInterestRate).ToList();
            else if (sortOrder == "lowerBoundInterestRate_desc")
                results = results.OrderByDescending(x => x.LowerBoundInterestRate).ToList();
            else if (sortOrder == "upperBoundInterestRate")
                results = results.OrderBy(x => x.UpperBoundInterestRate).ToList();
            else if (sortOrder == "upperBoundInterestRate_desc")
                results = results.OrderByDescending(x => x.UpperBoundInterestRate).ToList();
            else if (sortOrder == "incremental")
                results = results.OrderBy(x => x.IncrementalRate).ToList();
            else if (sortOrder == "incremental_desc")
                results = results.OrderByDescending(x => x.IncrementalRate).ToList();
            else if (sortOrder == "maturity")
                results = results.OrderBy(x => x.Maturity).ToList();
            else if (sortOrder == "maturity_desc")
                results = results.OrderByDescending(x => x.Maturity).ToList();
            else if (sortOrder == "future")
                results = results.OrderBy(x => x.FutureValue).ToList();
            else if (sortOrder == "future_desc")
                results = results.OrderByDescending(x => x.FutureValue).ToList();
            else
                results = results.OrderByDescending(x => x.Id).ToList();

            return _mapper.Map<IEnumerable<InvoiceViewModel>>(results);
        }

        public async Task<bool> SaveInvoiceComputation(InvoiceViewModel model)
        {
            var history = _mapper.Map<InvoiceHistory>(model);
            var result = await _repository.AddAsync(history);

            return (result != null);
        }
    }

}
