using ComputeFutureValue.Api.Data;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Api.Infrastructure.Repositories;
using ComputeFutureValue.Api.Infrastructure.Services;
using ComputeFutureValue.Api.Mapper;
using ComputeFutureValue.Common.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComputeFutureValue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins(new string[] { "https://localhost:7001", "https://localhost:4200" }).AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddDbContext<ComputeFutureValueDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("ApiConnectionString"));
            });

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IGenericRepository<InvoiceHistory>, GenericRepository<InvoiceHistory>>();


            services.AddAutoMapperMappingConfiguration();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ComputeFutureValueDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ComputeFutureValueApiSeeder.EnsureDataSeedAsync(context).Wait();
        }
    }
}
