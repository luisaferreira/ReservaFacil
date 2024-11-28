using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models;

[Table("Permissao")]
public class Permissao : Base
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
}