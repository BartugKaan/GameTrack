using GameTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTrack.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Genre>().HasData(
        new Genre { GenreId = 1, Name = "Action" },
        new Genre { GenreId = 2, Name = "Adventure" },
        new Genre { GenreId = 3, Name = "RPG" },
        new Genre { GenreId = 4, Name = "Simulation" },
        new Genre { GenreId = 5, Name = "Strategy" },
        new Genre { GenreId = 6, Name = "Sports" },
        new Genre { GenreId = 7, Name = "Puzzle" },

        new Genre { GenreId = 9, Name = "MMO" }
      );
    }
  }
}