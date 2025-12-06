using Microsoft.AspNetCore.Mvc;
using WebFamilyLogin.Data;
using WebFamilyLogin.Models;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            cliente.DataCadastro = DateTime.Now;

            // Aqui você pode aplicar hash na senha antes de salvar
            // cliente.SenhaHash = BCrypt.Net.BCrypt.HashPassword(cliente.SenhaHash);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        return View(cliente);
    }
}
