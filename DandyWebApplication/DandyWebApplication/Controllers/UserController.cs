/*using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DandyWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Register(UserModel user)
        {
            var jsonUserData = JsonSerializer.Serialize(user);
            bool result = await _apiService.RegisterUserAsync(jsonUserData);
            if (result)
                return View("Success");
            else
                return View("Error");
        }
    }

}
*/