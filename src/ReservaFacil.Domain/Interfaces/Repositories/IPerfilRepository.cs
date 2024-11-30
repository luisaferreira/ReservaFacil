using ReservaFacil.Application.DTOs;
using ReservaFacil.Domain.Interfaces.Repositories.Shared;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Domain.Interfaces.Repositories;

public interface IPerfilRepository : IBaseRepository<Perfil>
{
    Task<List<(Perfil perfil, IEnumerable<Permissao> permissoes)>> GetPerfilComPermissoesAsync();
}