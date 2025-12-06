using Microsoft.AspNetCore.Mvc;

namespace WebFamilyLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(); // procura Views/Login/Index.cshtml
        }

        public IActionResult Cadastro()
        {
            return View(); // procura Views/Login/Cadastro.cshtml
        }
    }
}
