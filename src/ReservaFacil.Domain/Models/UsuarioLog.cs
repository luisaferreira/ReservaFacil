using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("UsuarioLog")]
    public class UsuarioLog : Base
    {
        public int UsuarioId { get; set; }
        public string Acao { get; set; }
        public DateTime DataAcao { get; set; }

        public UsuarioLog()
        {
            DataAcao = DateTime.Now;
        }
    }
}
