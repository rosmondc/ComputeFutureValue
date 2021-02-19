using ComputeFutureValue.Razor.Services;
using ComputeFutureValue.Razor.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Polly;
using System;

namespace ComputeFutureValue.Razor
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
            services.AddControllersWithViews();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<IInvoiceService, InvoiceService>(c =>
            {
                c.BaseAddress = new Uri(Configuration["ApiUrl"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Poc");
            })
                .AddTransientHttpErrorPolicy(policyBuilder =>
                   policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 2,
                   durationOfBreak: TimeSpan.FromMilliseconds(300))).SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Invoice/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Invoice}/{action=Index}/{id?}");
            });
        }
    }
}
