using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories
{
    public class PerfilPermissaoRepository : BaseRepository<PerfilPermissao>, IPerfilPermissaoRepository
    {
        public PerfilPermissaoRepository(IConfiguration configuration) 
            : base(configuration) { }
    }
}
