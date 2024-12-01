using Microsoft.AspNetCore.Mvc;

namespace ReservaFacil.Web.Controllers
{
    public class ReservaSalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
