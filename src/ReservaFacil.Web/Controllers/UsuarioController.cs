using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Web.Models;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApiService _apiService;

        public UsuarioController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _apiService.PostDataAsync("https://localhost:44390/Usuario", usuario);

                    return Json(success ? new { success = true, message = "Usuário adicionado com sucesso!" } : new { success = false, message = "Erro ao adicionar o usuário. Tente novamente mais tarde." });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false, message = "Ocorreu um erro interno. Tente novamente mais tarde.",
                        errorDetails = ex.Message
                    });
                }
            }
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new { success = false, errors });
        }
    }
}