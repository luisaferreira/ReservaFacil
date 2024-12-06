using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var status = await _statusRepository.ObterAsync();

            return Ok(status);
        }
    }
}
