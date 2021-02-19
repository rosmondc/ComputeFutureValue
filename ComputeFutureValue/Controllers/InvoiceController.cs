using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Common.ViewModels;
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
            {
                var futureAmount = _service.CalculateFutureAmount(model);

                if (futureAmount > 0)
                {
                    var result = await _service.SaveComputation(model);
                    if (result)
                        return futureAmount;
                }
            }
            return 0;
        }

    }
}


