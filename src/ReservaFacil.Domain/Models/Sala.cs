using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Sala")]
    public class Sala : Base
    {
        public int CursoId { get; set; }
        public string Bloco { get; set; }
        public string Numero { get; set; }
        public bool Laboratorio { get; set; }
    }
}
