using ComputeFutureValue.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        decimal CalculateFutureAmount(InvoiceHistoryViewModel model);

        Task<IEnumerable<InvoiceHistoryViewModel>> GetAllHistory();

        Task<bool> SaveComputation(InvoiceHistoryViewModel model);
    }
}