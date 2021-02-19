using ComputeFutureValue.Api.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Data
{
    public static class ComputeFutureValueApiSeeder
    {
        public static async Task EnsureDataSeedAsync(IWebHostEnvironment hosting, ComputeFutureValueDbContext context)
        {
            context.Database.EnsureCreated();


            if (!context.Histories.Any())
            {
                var histories = new List<InvoiceHistory>()
                {
                    new InvoiceHistory() { 
                        PresentValue = 1000, 
                        LowerBoundInterestRate = 0.10M, 
                        UpperBoundInterestRate = 0.50M, 
                        IncrementaltRate = 0.20M, Maturity = 4, 
                        FutureValue = 3217.5M  }
                };

                await context.SaveChangesAsync();
            }
        }
    }
}
