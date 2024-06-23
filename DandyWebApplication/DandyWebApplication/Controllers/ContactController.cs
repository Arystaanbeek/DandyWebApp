using Microsoft.AspNetCore.Mvc;

namespace DandyWebApplication.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
