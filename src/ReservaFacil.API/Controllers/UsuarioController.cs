using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Data.Repositories;
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
        public IActionResult Inserir(Usuario usuario)
        {
            _usuarioRepository.InserirAsync(usuario);

            return StatusCode(200);
        }
    }
}
