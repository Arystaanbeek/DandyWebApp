using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class SignUpController : Controller
{
    private readonly HttpClient _httpClient;

    public SignUpController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string firstName, string lastName, string email, string retypeEmail)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || email != retypeEmail)
        {
            return View("Error", (object)"Please provide all required fields correctly.");
        }

        var userData = new
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        var jsonUserData = JsonSerializer.Serialize(userData);
        var content = new StringContent(jsonUserData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5108/api/Account/register", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View("Error", (object)"Registration failed.");
        }
    }

    [HttpGet]
    public IActionResult Success()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Error(string message)
    {
        ViewData["ErrorMessage"] = message;
        return View((object)message);
    }
}
