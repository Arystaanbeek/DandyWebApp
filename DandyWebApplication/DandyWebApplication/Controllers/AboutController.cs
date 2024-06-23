using Microsoft.AspNetCore.Mvc;

namespace DandyWebApplication.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
