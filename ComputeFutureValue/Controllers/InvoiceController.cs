using ComputeFutureValue.Services.Interfaces;
using ComputeFutureValue.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ComputeFutureValue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IComputeService _service;

        public InvoiceController(IComputeService service)
        {
            _service = service;
        }


        [HttpPost, Route("compute")]
        public decimal Compute(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                return _service.CalculateFutureAmount(model);
            }

            return 0;
        }
    }
}


