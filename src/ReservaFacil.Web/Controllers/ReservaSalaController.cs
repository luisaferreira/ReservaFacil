using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Models;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers
{
    public class ReservaSalaController : Controller
    {
        private readonly ApiService _apiService;

        public ReservaSalaController(IConfiguration configuration)
        {
            _apiService = new ApiService(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var status = await _apiService.GetDataAsync<IEnumerable<Status>>("Status");

            return View(status);
        }
    }
}
