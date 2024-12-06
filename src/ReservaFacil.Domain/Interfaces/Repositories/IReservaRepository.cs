using ReservaFacil.Domain.Interfaces.Repositories.Shared;
using ReservaFacil.Domain.Models;
using System.Data;

namespace ReservaFacil.Domain.Interfaces.Repositories
{
    public interface IReservaRepository : IBaseRepository<Reserva>
    {
        Task<DataSet> PesquisarReserva(string pesquisa, int statusId, DateTime? dataInicial, DateTime? dataFinal);
    }
}
