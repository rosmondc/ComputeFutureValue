using ComputeFutureValue.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Razor.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceViewModel>> GetInvoicesAsync(string sortOrder);
        Task<string> ComputeInvoiceAsync(InvoiceViewModel model);
    }
}
