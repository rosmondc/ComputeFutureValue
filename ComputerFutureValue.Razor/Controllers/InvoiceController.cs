using ComputeFutureValue.Common.ViewModels;
using ComputeFutureValue.Razor.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ComputeFutureValue.Razor.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["presentValueSortParm"] = sortOrder == "presentValue" ? "presentValue_desc" : "presentValue";
            ViewData["lowerBoundInterestRateSortParm"] = sortOrder == "lowerBoundInterestRate" ? "lowerBoundInterestRate_desc" : "lowerBoundInterestRate";
            ViewData["upperBoundInterestRateSortParm"] = sortOrder == "upperBoundInterestRate" ? "upperBoundInterestRat_desc" : "upperBoundInterestRat";
            ViewData["incrementalSortParm"] = sortOrder == "incremental" ? "incremental_desc" : "incremental";
            ViewData["maturitySortParm"] = sortOrder == "maturity" ? "maturity_desc" : "maturity";
            ViewData["futureSortParm"] = sortOrder == "future" ? "future_desc" : "future";

            var results = await _service.GetInvoicesAsync(sortOrder);

            if (results != null)
                return View(results);

            return null;
        }

        public IActionResult Compute()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compute([FromForm] InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = JsonConvert.DeserializeObject<decimal>(await _service.ComputeInvoiceAsync(model));

                if (result > 0)
                {
                    return RedirectToAction("Index", "Invoice");
                }
                    

                ModelState.AddModelError(string.Empty, "Invalid computation attempt");
            }
            return View(model);
        }
    }
}
