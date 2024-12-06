using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("PerfilPermissao")]
    public class PerfilPermissao
    {
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }
    }
}
