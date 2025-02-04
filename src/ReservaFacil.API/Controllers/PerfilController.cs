using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
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
    public async Task<IActionResult> Obter()
    {
        var perfis = await _perfilRepository.ObterAsync();

        if (!perfis.Any())
            return NoContent();
        
        return Ok(perfis);
    }

    [HttpGet("perfil-com-permissoes")]
    public async Task<IActionResult> ObterPerfilComPermissoes()
    {
        var perfisComPermissoes  = await _perfilRepository.ObterPerfilComPermissoesAsync();
        
        if(perfisComPermissoes.Count == 0)
            return NoContent();
        
        var perfilComPermissoesDTO = perfisComPermissoes.Select(tuple =>
        {
            var perfilDTO = new PerfilDTO
            {
                Id = tuple.perfil.Id,
                Nome = tuple.perfil.Nome,
            };
            var permissoesDTO = tuple.permissoes.Select(p => new PermissaoDTO
            {
                IdPermissao = p.Id,
                PermissaoNome = p.Nome,
                Descricao = p.Descricao
            }).ToList();

            return new PerfilComPermissoesDTO
            {
                IdPerfil = perfilDTO.Id,
                PerfilNome = perfilDTO.Nome,
                Permissoes = permissoesDTO
            };
        }).ToList();
        
        return Ok(perfilComPermissoesDTO);
    }
}