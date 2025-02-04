using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models;

[Table("HorarioBloqueado")]
public class HorarioBloqueado : Base
{
    public int IdSala { get; set; }
    public DateTime HorarioInicial { get; set; }
    public DateTime HorarioFinal { get; set; }
}