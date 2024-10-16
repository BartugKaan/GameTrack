using GameTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTrack.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Game> Game { get; set; }
  }
}