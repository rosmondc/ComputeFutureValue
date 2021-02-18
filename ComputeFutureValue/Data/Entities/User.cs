namespace ComputeFutureValue.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public InvoiceHistory InvoiceHistory { get; set; }
    }
}
