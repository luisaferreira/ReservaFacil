using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Interfaces.Services;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController(IUsuarioService usuarioService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Inserir(UsuarioDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                PerfilId = (int)usuarioDto.PerfilId!,
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Matricula = usuarioDto.Matricula,
            };

            var permissoes = usuarioDto.PermissaoIds.Select(p => new Permissao { Id = p }).ToList();
            
            var usuarioCriado = await usuarioService.Cadastrar(usuario, permissoes);

            if (!usuarioCriado)
                return BadRequest("Erro ao criar o usuário");

            return CreatedAtAction(nameof(Inserir), new { id = usuarioCriado });
        }
    }
}
