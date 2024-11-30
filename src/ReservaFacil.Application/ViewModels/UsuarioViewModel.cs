using ReservaFacil.Domain.Models;

namespace ReservaFacil.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Perfil> Perfis { get; set; }
        public int PaginaAtiva { get; set; }
        public int QuantidadeUsuarios { get; set; }
        public int QuantidadePaginas { get; set; }
    }
}
