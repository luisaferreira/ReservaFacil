using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories;

public class UsuarioPermissaoRepository : BaseRepository<UsuarioPermissao>, IUsuarioPermissaoRepository
{
    private readonly IConfiguration _configuration;
    
    public UsuarioPermissaoRepository(IConfiguration configuration) 
        : base(configuration) {}
}