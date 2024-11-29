using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models;

[Table("UsuarioPermissao")]
public class UsuarioPermissao
{
    public int IdUsuario {get; set;}
    
    public int IdPermissao {get; set;}
}