using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputeFutureValue.Common.Entities
{
    public class InvoiceHistory
    {
        public int Id { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required, Column(TypeName = "decimal(18, 6)")]
        public decimal PresentValue { get; set; }

        [Required, Range(1, 99), Column(TypeName = "decimal(18, 6)")]
        public decimal LowerBoundInterestRate { get; set; }

        [Required, Range(1, 99), Column(TypeName = "decimal(18, 6)")]
        public decimal UpperBoundInterestRate { get; set; }

        [Required, Range(1, 99), Column(TypeName = "decimal(18, 6)")]
        public decimal IncrementalRate { get; set; }

        [Required, Range(1, 20), Column(TypeName = "int")]
        public int Maturity { get; set; }

        [Required, Column(TypeName = "decimal(18, 6)")]
        public decimal FutureValue { get; set; }

    }
}
