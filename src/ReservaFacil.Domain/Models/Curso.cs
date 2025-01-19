using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models;

[Table("Curso")]
public class Curso : Base
{
    public int IdNivelGraduacao { get; set; }
    public string? Nome { get; set; }
}
