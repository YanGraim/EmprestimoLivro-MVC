using Microsoft.AspNetCore.Mvc;

namespace EmpresTech.Controllers;

public class EmprestimoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}