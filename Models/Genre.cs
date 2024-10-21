using System.ComponentModel.DataAnnotations;

namespace GameTrack.Models
{
  // Define the Genre class
  public class Genre
  {
    [Key]
    public int GenreId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
  }
}