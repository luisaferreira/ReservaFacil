using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class PeriodoBloqueadoRepository : BaseRepository<PeriodoBloqueado>, IPeriodoBloqueadoRepository
    {
        public PeriodoBloqueadoRepository(IConfiguration configuration)
            : base(configuration) { }
    }
}
