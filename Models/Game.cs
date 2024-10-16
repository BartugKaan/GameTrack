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
    public string? Genre { get; set; }

    [Display(Name = "Game Developer")]
    public string? Developer { get; set; }

    [Required(ErrorMessage = "Finished Date is required")]
    [Display(Name = "Release Date")]
    public DateTime FinishedDate { get; set; }

    [Required(ErrorMessage = "Rating is required")]
    [Display(Name = "Game Rating")]
    public int Rating { get; set; }

    [Required(ErrorMessage = "Review is required")]
    [Display(Name = "Game Review")]
    public string? Review { get; set; }

  }
}