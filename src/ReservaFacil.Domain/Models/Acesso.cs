using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Acesso")]
    public class Acesso : Base
    {
        public int IdReserva { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
