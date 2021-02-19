using System.ComponentModel.DataAnnotations;

namespace ComputeFutureValue.Common.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public InvoiceHistory InvoiceHistory { get; set; }
    }
}
