using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Reserva")]
    public class Reserva : Base
    {
        public int IdUsuario { get; set; }
        public int IdSala { get; set; }
        public int IdStatus { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataInclusao { get; set; }

        public Reserva()
        {
            DataInclusao = DateTime.Now;
        }
    }
}
