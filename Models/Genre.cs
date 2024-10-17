using System.ComponentModel.DataAnnotations;

namespace GameTrack.Models
{
  public class Genre
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Genre Name")]
    public string? Name { get; set; }
  }
}