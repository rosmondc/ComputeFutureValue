using ComputeFutureValue.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Data
{
    public static class ComputeFutureValueApiSeeder
    {
        public static async Task EnsureDataSeedAsync(ComputeFutureValueDbContext context)
        {
            context.Database.EnsureCreated();


            if (!context.Histories.Any())
            {
                var histories = new List<InvoiceHistory>()
                {
                    new InvoiceHistory() { 
                        PresentValue = 1000, 
                        LowerBoundInterestRate = 10M, 
                        UpperBoundInterestRate = 50M, 
                        IncrementalRate = 20M, 
                        Maturity = 4, 
                        FutureValue = 3217.5M  }
                };

                context.Histories.AddRange(histories);
                await context.SaveChangesAsync();
            }
        }
    }
}
