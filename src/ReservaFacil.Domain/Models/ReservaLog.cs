using ReservaFacil.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFacil.Domain.Models
{
    [Table("ReservaLog")]
    public class ReservaLog : Base
    {
        public int ReservaId { get; set; }
        public int StatusId { get; set; }
        public DateTime DataAcao { get; set; }
    }
}
