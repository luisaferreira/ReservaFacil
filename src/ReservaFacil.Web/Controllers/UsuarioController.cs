using Microsoft.AspNetCore.Mvc;

namespace ReservaFacil.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
