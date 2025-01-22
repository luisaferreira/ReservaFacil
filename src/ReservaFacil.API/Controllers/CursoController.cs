using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class CursoController(ICursoRepository cursoRepository) : Controller
{
    private readonly ICursoRepository _cursoRepository = cursoRepository;

    [HttpGet("Obter")]
    public async Task<IActionResult> Obter()
    {
        var cursos = await _cursoRepository.ObterAsync();

        return Ok(cursos);
    }
}
