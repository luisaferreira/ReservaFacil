using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class PerfilController : Controller
{
    private readonly IPerfilRepository _perfilRepository;

    public PerfilController(IPerfilRepository perfilRepository)
        => _perfilRepository = perfilRepository;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var perfis = await _perfilRepository.ObterAsync();

        if (!perfis.Any())
            return NoContent();
        
        return Ok(perfis);
    }

    [HttpGet("perfil-com-permissoes")]
    public async Task<IActionResult> GetPerfilComPermissoes()
    {
        var perfisComPermissoes  = await _perfilRepository.GetPerfilComPermissoesAsync();
        
        if(!perfisComPermissoes .Any())
            return NoContent();
        
        return Ok(perfisComPermissoes);
    }
}