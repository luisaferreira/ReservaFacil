using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("UsuarioCurso")]
    public class UsuarioCurso
    {
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
    }
}
