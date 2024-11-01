using EmpresTech.Data;
using EmpresTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpresTech.Controllers;

public class EmprestimoController : Controller
{
    private readonly ApplicationDbContext _db;

    public EmprestimoController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
        return View(emprestimos);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(EmprestimosModel emprestimos)
    {
        if (ModelState.IsValid)
        {
            _db.Emprestimos.Add(emprestimos);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
}