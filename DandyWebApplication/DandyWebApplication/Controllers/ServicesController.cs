using Microsoft.AspNetCore.Mvc;

namespace DandyWebApplication.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
