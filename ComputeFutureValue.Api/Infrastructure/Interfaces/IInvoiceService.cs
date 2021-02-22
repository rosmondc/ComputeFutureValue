using ComputeFutureValue.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        decimal CalculateFutureAmount(InvoiceViewModel model);

        Task<IEnumerable<InvoiceViewModel>> GetAllHistory(string sortOrder);

        Task<bool> SaveInvoiceComputation(InvoiceViewModel model);
    }
}