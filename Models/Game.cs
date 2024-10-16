using System;
using System.ComponentModel.DataAnnotations;
namespace GameTrack.Models
{
  public class Game
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [Display(Name = "Game Title")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    [Display(Name = "Game Genre")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Release Date is required")]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Developer is required")]
    [Display(Name = "Game Developer")]
    public string Developer { get; set; }
  }
}