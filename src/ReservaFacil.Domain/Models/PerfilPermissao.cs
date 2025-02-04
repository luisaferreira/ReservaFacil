using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("PerfilPermissao")]
    public class PerfilPermissao
    {
        public int IdPerfil { get; set; }
        public int IdPermissao { get; set; }
    }
}
