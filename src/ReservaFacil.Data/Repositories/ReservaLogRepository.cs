using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class ReservaLogRepository : BaseRepository<ReservaLog>, IReservaLogRepository
    {
        public ReservaLogRepository(IConfiguration configuration)
            : base(configuration) { }
    }
}
