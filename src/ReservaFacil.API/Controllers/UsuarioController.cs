using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Data.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;


        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Inserir(Usuario usuario)
        {
            _usuarioRepository.Inserir(usuario);

            return StatusCode(200);
        }
    }
}
