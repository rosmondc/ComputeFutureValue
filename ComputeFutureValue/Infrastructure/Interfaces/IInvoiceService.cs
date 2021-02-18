using ComputeFutureValue.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        Task<decimal> CalculateFutureAmount(InvoiceHistoryViewModel model);

        Task<IEnumerable<InvoiceHistoryViewModel>> GetAllHistory();
    }
}