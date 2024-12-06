using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("Status")]
    public class Status : Base
    {
        public string Nome { get; set; }
    }
}
