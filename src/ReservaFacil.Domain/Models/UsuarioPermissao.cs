using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models;

[Table("UsuarioPermissao")]
public class UsuarioPermissao
{
    public int IdUsuario {get; set;}
    
    public int IdPermissao {get; set;}
}