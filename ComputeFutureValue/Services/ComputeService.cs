using ComputeFutureValue.Services.Interfaces;
using ComputeFutureValue.ViewModel;

namespace ComputeFutureValue.Services
{
    public class ComputeService : IComputeService
    {
        public ComputeService()
        { }

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

            return futureValue;
        }
    }
}
