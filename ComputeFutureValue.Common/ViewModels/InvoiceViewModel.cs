using ComputeFutureValue.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace ComputeFutureValue.Common.ViewModels
{
    public class InvoiceViewModel
    {

        public int Id { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Present Value")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal PresentValue { get; set; }

        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Lower Bound")]
        public decimal LowerBoundInterestRate { get; set; }


        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Upper Bound")]
        public decimal UpperBoundInterestRate { get; set; }

        [Required, Range(1, 99, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Increment Rate")]
        public decimal IncrementalRate { get; set; }

        [Required, Range(1, 20, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Maturity")]
        public int Maturity { get; set; }

        [Display(Name = "Future Value")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal FutureValue { get; set; }

        [StringLength(20, ErrorMessage = "User name should not excedd to 20 characters")]
        public User User { get; set; }
    }
}
