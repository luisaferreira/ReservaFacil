using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Curso")]
    public class Curso : Base
    {
        public string Nome { get; set; }
    }
}
