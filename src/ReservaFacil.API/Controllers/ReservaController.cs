using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Application.ViewModels;
using ReservaFacil.Domain.Interfaces.Repositories;
using System.Data;

namespace ReservaFacil.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisar([FromBody]PesquisaReservaDTO pesquisaReservaDTO)
        {
            var dataSet = await _reservaRepository.PesquisarReserva(pesquisaReservaDTO.Pesquisa, pesquisaReservaDTO.StatusId, pesquisaReservaDTO.DataInicial, pesquisaReservaDTO.DataFinal);

            var viewModel = dataSet.Tables[0]
                .AsEnumerable()
                .Select(row => new ReservaViewModel
            {
                    Id = Convert.ToInt32(row["Id"]),
                    Numero = row["Numero"].ToString(),
                    DataInicial = Convert.ToDateTime(row["DataInicial"]),
                    DataFinal = Convert.ToDateTime(row["DataFinal"]),
                    DataSolicitacao = Convert.ToDateTime(row["DataSolicitacao"]),
                    Solicitante = row["Solicitante"].ToString(),
                    Status = row["Status"].ToString(),
                    StatusId = Convert.ToInt32(row["StatusId"]),
                    Laboratorio = Convert.ToBoolean(row["Laboratorio"])
            }).ToList();

            return Ok(viewModel);
        }
    }
}
