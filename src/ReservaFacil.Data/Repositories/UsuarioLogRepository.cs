using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class UsuarioLogRepository : BaseRepository<UsuarioLog>, IUsuarioLogRepository
    {
        public UsuarioLogRepository(IConfiguration configuration)
            : base(configuration) { }
    }
}
