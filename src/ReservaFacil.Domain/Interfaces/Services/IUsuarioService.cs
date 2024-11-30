using ReservaFacil.Domain.Models;

namespace ReservaFacil.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> Cadastrar(Usuario usuario, List<Permissao> permissoes);
    }
}
