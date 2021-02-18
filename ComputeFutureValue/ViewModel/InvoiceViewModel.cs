using ComputeFutureValue.Data.Entities;

namespace ComputeFutureValue.ViewModel
{
    public class InvoiceViewModel
    {
        public decimal PresentValue { get; set; }

        public decimal LowerBoundInterestRate { get; set; }

        public decimal UpperBoundInterestRate { get; set; }

        public decimal IncrementaltRate { get; set; }

        public int Maturity { get; set; }

        public User User { get; set; }
    }
}
