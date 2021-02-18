using ComputeFutureValue.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputeFutureValue.Data
{
    public class ComputeDbContext : DbContext
    {
        public ComputeDbContext()
        {

        }

        public DbSet<InvoiceHistory> Histories { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
