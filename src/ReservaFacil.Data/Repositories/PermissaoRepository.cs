using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories;

public class PermissaoRepository : BaseRepository<Permissao>, IPermissaoRepository {

    public PermissaoRepository(IConfiguration configuration)
        : base(configuration) { }
}