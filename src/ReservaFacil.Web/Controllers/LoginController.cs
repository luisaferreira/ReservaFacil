using Microsoft.AspNetCore.Mvc;

namespace ReservaFacil.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
