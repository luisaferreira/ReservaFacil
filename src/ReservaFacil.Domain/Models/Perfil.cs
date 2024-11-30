using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models;

[Table("Perfil")]
public class Perfil : Base
{
    public string? Nome { get; set; }
}