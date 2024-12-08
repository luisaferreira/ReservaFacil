using Microsoft.AspNetCore.Mvc;

namespace ReservaFacil.Web.Controllers;

public class SalaController(IConfiguration configuration) : Controller
{

    public IActionResult Index()
        => View();
    
    public IActionResult Cadastro()
        => View();
}