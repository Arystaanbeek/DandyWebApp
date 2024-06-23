using Microsoft.AspNetCore.Mvc;

namespace DandyWebApplication.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
