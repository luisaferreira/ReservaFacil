using ReservaFacil.Domain.Models;

namespace ReservaFacil.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Perfil> Perfis { get; set; }
    }
}
