using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("ReservaLog")]
    public class ReservaLog : Base
    {
        public int IdReserva { get; set; }
        public int IdStatus { get; set; }
        public DateTime DataAcao { get; set; }
    }
}
