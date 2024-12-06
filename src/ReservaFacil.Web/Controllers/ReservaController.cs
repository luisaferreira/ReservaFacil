using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Application.ViewModels;
using ReservaFacil.Domain.Models;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ApiService _apiService;

        public ReservaController(IConfiguration configuration)
        {
            _apiService = new ApiService(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var status = await _apiService.GetDataAsync<IEnumerable<Status>>("Status");

            return View(status);
        }

        public async Task<IActionResult> Pesquisar(int numeroPagina, PesquisaReservaDTO pesquisaReservaDTO)
        {
            var reservas = await _apiService.GetDataAsync<IEnumerable<ReservaViewModel>>("Reserva", pesquisaReservaDTO);

            if(reservas == null)
                return PartialView("_Reservas", null);

            var viewModel = new ListaReservaViewModel
            {
                Reservas = reservas.Skip((numeroPagina - 1) * 15).Take(15).ToList(),
                PaginaAtiva = numeroPagina,
                QuantidadeReservas = reservas.Count()
            };

            viewModel.QuantidadePaginas = (int)Math.Ceiling(viewModel.QuantidadeReservas / (double)15);

            return PartialView("_Reservas", viewModel);
        }
    }
}
