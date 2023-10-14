using System.ComponentModel.DataAnnotations;

namespace TeslaDrive.Models
{
    public class PalmaAirport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}