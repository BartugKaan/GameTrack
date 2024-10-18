using System.ComponentModel.DataAnnotations;

namespace GameTrack.Models
{
  public class Genre
  {
    [Key]
    public int GenreId { get; set; }

    public string Name { get; set; } = string.Empty;
  }
}