using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFamilyLogin.Data;     // <- necessário para AppDbContext
using WebFamilyLogin.Models;   // <- necessário para Cliente e Grupo

namespace WebFamilyLogin.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.Include(c => c.Grupo).ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            ViewBag.Grupos = _context.Grupos.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
