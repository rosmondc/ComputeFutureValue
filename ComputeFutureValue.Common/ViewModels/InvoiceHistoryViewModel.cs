using ComputeFutureValue.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace ComputeFutureValue.Common.ViewModels
{
    public class InvoiceHistoryViewModel
    {
        
        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public decimal PresentValue { get; set; }

        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        public decimal LowerBoundInterestRate { get; set; }


        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        public decimal UpperBoundInterestRate { get; set; }

        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        public decimal IncrementaltRate { get; set; }

        [Required, Range(1, 20, ErrorMessage = "Please enter valid integer Number")]
        public int Maturity { get; set; }

        public decimal FutureValue { get; set; }

        [StringLength(20, ErrorMessage = "User name should not excedd to 20 characters")]
        public User User { get; set; }
    }
}
