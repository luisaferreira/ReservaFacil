using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class PermissaoController : Controller
{
    private readonly IPermissaoRepository _permissaoRepository;

    public PermissaoController(IPermissaoRepository permissaoRepository)
        => _permissaoRepository = permissaoRepository;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var permissoes = await _permissaoRepository.ObterAsync();

        if (!permissoes.Any())
            return NoContent();
        
        return Ok(permissoes);
    }
}