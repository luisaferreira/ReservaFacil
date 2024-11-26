using System.Diagnostics;
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
        public IActionResult Inserir([FromBody] Usuario usuario)
        {
            try
            {
                Debug.WriteLine("Caiu na controller da api...");
                _usuarioRepository.Inserir(usuario);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            
        }
    }
}
