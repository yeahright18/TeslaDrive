using System.ComponentModel.DataAnnotations;

namespace TeslaDrive.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int TelephoneNumber { get; set; }
    }
}