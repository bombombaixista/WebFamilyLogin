using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFamilyLogin.Data;     // <- necessário para AppDbContext
using WebFamilyLogin.Models;   // <- necessário para Grupo e Cliente

namespace WebFamilyLogin.Controllers
{
    public class GrupoController : Controller
    {
        private readonly AppDbContext _context;

        public GrupoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var grupos = _context.Grupos.Include(g => g.Clientes).ToList();
            return View(grupos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
