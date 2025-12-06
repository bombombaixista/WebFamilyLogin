using Microsoft.AspNetCore.Mvc;
using WebFamilyLogin.Data;
using WebFamilyLogin.Models;

namespace WebFamilyLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Login/Cadastro
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(); // Views/Login/Cadastro.cshtml
        }

        // POST /Login/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Cliente cliente)
        {
            // Log simples para diagnosticar fluxo
            Console.WriteLine("POST /Login/Cadastro chamado");

            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            // Preenche campos de sistema
            cliente.DataCadastro = DateTime.Now;

            // Se quiser usar hash de senha (opcional):
            // cliente.SenhaHash = BCrypt.Net.BCrypt.HashPassword(cliente.SenhaHash);

            _context.Clientes.Add(cliente);
            var changed = _context.SaveChanges();
            Console.WriteLine($"Linhas afetadas: {changed}");

            // Redireciona após sucesso
            return RedirectToAction("Index", "Home");
        }

        // GET /Login (tela de login)
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Views/Login/Index.cshtml (se existir)
        }
    }
}
