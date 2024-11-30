using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models;

[Table("UsuarioPermissao")]
public class UsuarioPermissao
{
    public int UsuarioId {get; set;}
    
    public int PermissaoId {get; set;}
}