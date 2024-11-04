using Microsoft.AspNetCore.Mvc;

namespace EmpresTech.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Registrar()
    {
        return View();
    }
}