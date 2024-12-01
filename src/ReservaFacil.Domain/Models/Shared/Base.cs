using System.ComponentModel.DataAnnotations;

namespace ReservaFacil.Domain.Models.Shared
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
