using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }


        [HttpGet, Route("")]
        public async Task<IActionResult> Index(string sortOrder)
        {
            var results = await _service.GetAllHistory(sortOrder);
            if (results.Count() > 0)
                return Ok(results);
            else
                return NotFound();
        }

        [HttpPost, Route("compute")]
        public async Task<decimal> Compute(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var futureAmount = _service.CalculateFutureAmount(model);

                if (futureAmount > 0)
                {
                    var result = await _service.SaveInvoiceComputation(model);
                    if (result)
                        return futureAmount;
                }
            }
            return 0;
        }

    }
}


