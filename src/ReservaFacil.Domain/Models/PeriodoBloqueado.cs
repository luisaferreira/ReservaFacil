using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("PeriodoBloqueado")]
    public class PeriodoBloqueado : Base
    {
        public int SalaId { get; set; }
        public int DiaSemana { get; set; }
        public TimeOnly HorarioInicial { get; set; }
        public TimeOnly FinalInicial { get; set; }
    }
}
