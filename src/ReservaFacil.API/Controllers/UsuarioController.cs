using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(UsuarioDTO usuario)
        {
            var usuarioCriado = await _usuarioRepository.InserirUsuarioComPermissoes(usuario);

            if (usuarioCriado <= 0)
                return BadRequest("Erro ao criar o usuário");

            return CreatedAtAction(nameof(Inserir), new { id = usuarioCriado });
        }
    }
}
