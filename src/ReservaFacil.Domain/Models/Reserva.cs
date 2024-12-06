using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Reserva")]
    public class Reserva : Base
    {
        public int UsuarioId { get; set; }
        public int SalaId { get; set; }
        public int StatusId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataInclusao { get; set; }

        public Reserva()
        {
            DataInclusao = DateTime.Now;
        }
    }
}
