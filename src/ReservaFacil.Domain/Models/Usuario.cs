using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Usuario")]
    public class Usuario : Base
    {
        public Usuario()
        {
            Ativo = true;
            CriadoEm = DateTime.Now;
        }
        
        public int PerfilId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Matricula { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }
    }
}
