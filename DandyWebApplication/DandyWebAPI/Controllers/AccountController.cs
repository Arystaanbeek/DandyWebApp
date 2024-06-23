using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(UserModel userModel)
    {
        _logger.LogInformation("Метод RegisterUser вызван с email: {Email}", userModel.Email);

        var userExists = await _context.Users.AnyAsync(u => u.Email == userModel.Email);
        if (userExists)
        {
            _logger.LogWarning("Регистрация не удалась: пользователь с email {Email} уже существует.", userModel.Email);
            return BadRequest("Пользователь с таким email уже существует.");
        }

        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Пользователь с email {Email} успешно зарегистрирован.", userModel.Email);
        return Ok(new { message = "Пользователь успешно зарегистрирован" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            return BadRequest("Invalid email or password.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return Ok(new { message = "Login successful" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logout successful" });
    }
}
