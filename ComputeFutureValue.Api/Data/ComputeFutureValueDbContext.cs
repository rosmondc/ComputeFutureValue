using ComputeFutureValue.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputeFutureValue.Api.Data
{
    public class ComputeFutureValueDbContext : DbContext
    {
        public ComputeFutureValueDbContext(DbContextOptions<ComputeFutureValueDbContext> options) : base(options)
        {
        }

        public DbSet<InvoiceHistory> Histories { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
