using ComputeFutureValue.ViewModel;

namespace ComputeFutureValue.Services.Interfaces
{
    public interface IComputeService
    {
        decimal CalculateFutureAmount(InvoiceViewModel model);
    }
}