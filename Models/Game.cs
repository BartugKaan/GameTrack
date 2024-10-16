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

    [Display(Name = "Developer")]
    public string? Developer { get; set; }

    [Required(ErrorMessage = "Finished Date is required")]
    [Display(Name = "Finished Date")]
    public DateTime FinishedDate { get; set; }

    [Required(ErrorMessage = "Rating is required")]
    [Display(Name = "Game Rating")]
    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
    public int Rating { get; set; }

    [Required(ErrorMessage = "Review is required")]
    [Display(Name = "Game Review")]
    public string? Review { get; set; }

  }
}