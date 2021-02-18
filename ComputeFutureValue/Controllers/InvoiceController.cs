using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }


        [HttpGet, Route("")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _service.GetAllHistory());
        }

        [HttpPost, Route("compute")]
        public async Task<decimal> Compute(InvoiceHistoryViewModel model)
        {
            if (ModelState.IsValid)
                return await _service.CalculateFutureAmount(model);

            return 0;
        }

    }
}


