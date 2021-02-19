using ComputeFutureValue.Common.ViewModels;
using ComputeFutureValue.Razor.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComputeFutureValue.Razor.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HttpClient _httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<InvoiceViewModel>> GetInvoicesAsync()
        {
            var response = await _httpClient.GetAsync($"api/invoice");
            var results = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<InvoiceViewModel>>(results);

            return null;
        }

        public async Task<string> ComputeInvoiceAsync(InvoiceViewModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/invoice/compute", content);
            var results = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return results;

            return null;
        }
    }
}
