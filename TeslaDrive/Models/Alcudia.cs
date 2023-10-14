using System.ComponentModel.DataAnnotations;

namespace TeslaDrive.Models
{
    public class Alcudia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}