namespace ComputeFutureValue.Data.Entities
{
    public class InvoiceHistory
    {
        public int Id { get; set; }
        public int PresentValue { get; set; }

        public decimal LowerBoundInterestRate { get; set; }

        public decimal UpperBoundInterestRate { get; set; }

        public decimal IncrementaltRate { get; set; }

        public int Maturity { get; set; }

    }
}
