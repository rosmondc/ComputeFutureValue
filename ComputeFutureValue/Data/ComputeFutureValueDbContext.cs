using ComputeFutureValue.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputeFutureValue.Api.Data
{
    public class ComputeFutureValueDbContext : DbContext
    {
        public ComputeFutureValueDbContext()
        {

        }

        public DbSet<InvoiceHistory> Histories { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
