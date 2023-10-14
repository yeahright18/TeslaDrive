using System.ComponentModel.DataAnnotations;

namespace TeslaDrive.Models
{
  public class Car
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Model { get; set; }
    public int Hp { get; set; }
    public int Range { get; set; }
  }
}
