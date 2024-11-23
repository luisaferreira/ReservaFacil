using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models
{
    public class Usuario : Base
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
