using System.ComponentModel.DataAnnotations.Schema;
using ReservaFacil.Domain.Models.Shared;

namespace ReservaFacil.Domain.Models
{
    [Table("Sala")]
    public class Sala : Base
    {
        public int CursoId { get; set; }
        public string? Bloco { get; set; }
        public int Numero { get; set; }
        public bool Laboratorio { get; set; }
    }
}
