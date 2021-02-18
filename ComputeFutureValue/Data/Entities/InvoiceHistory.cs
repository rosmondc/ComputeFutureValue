using System.ComponentModel.DataAnnotations;

namespace ComputeFutureValue.Api.Data.Entities
{
    public class InvoiceHistory
    {
        public int Id { get; set; }


        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PresentValue { get; set; }

        [Required, Range(1, 99)]
        public decimal LowerBoundInterestRate { get; set; }

        [Required, Range(1, 99)]
        public decimal UpperBoundInterestRate { get; set; }

        [Required, Range(1, 99)]
        public decimal IncrementaltRate { get; set; }

        [Required, Range(1, 20)]
        public int Maturity { get; set; }

        [Required]
        public decimal FutureValue { get; set; }

    }
}
