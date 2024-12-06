using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("UsuarioCurso")]
    public class UsuarioCurso
    {
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
    }
}
