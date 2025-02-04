using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Models;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers;

public class SalaController(IConfiguration configuration) : Controller
{
    private readonly ApiService _apiService = new ApiService(configuration);

    public IActionResult Index()
        => View();
    
    public async Task<IActionResult> Cadastro()
    {
        var cursos = await _apiService.GetDataAsync<IEnumerable<Curso>>("Curso/Obter");
        return View(cursos);
    }
}