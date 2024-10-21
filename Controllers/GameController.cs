using GameTrack.Data;
using GameTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameTrack.Controllers
{
  public class GameController : Controller
  {
    private readonly ApplicationDbContext _context;

    public GameController(ApplicationDbContext context)
    {
      _context = context;
    }

    private bool GameExists(int id)
    {
      return _context.Games.Any(e => e.Id == id);
    }

    private async Task SetGenresAsync()
    {
      // Get all games
      var games = await _context.Games
       .Include(g => g.GenreNavigation)
       .ToListAsync();

      // Set the GenreNavigation property for each game
      foreach (var game in games)
      {
        game.GenreNavigation = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == game.Genre);
      }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      // Store all genres in ViewBag
      ViewBag.Genres = await _context.Genres.ToListAsync();
      await SetGenresAsync();

      return View(await _context.Games.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
      ViewBag.Categories = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Game game, IFormFile imageFile)
    {
      var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };

      if (imageFile != null)
      {
        // Check if the file is an image
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!allowenExtensions.Contains(extension))
        {
          ModelState.AddModelError("", "Only .jpg, .png, .jpeg files are allowed!");
        }
        else
        {
          // Check if the file size is less than 100MB
          if (imageFile.Length > 100 * 1024 * 1024)
          {
            ModelState.AddModelError("", "File size must be less than 100MB!");
          }
          // Generate a random file name
          var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
          var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
          try
          {
            using (var stream = new FileStream(path, FileMode.Create))
            {
              await imageFile.CopyToAsync(stream);
            }
            Console.WriteLine("Image uploaded successfully!");
            game.Image = randomFileName;
            Console.WriteLine(game.Image);
          }
          catch
          {
            ModelState.AddModelError("", "There was an error while uploading the image!");
          }
        }
      }
      if (ModelState.IsValid)
      {
        // Add the game to the database
        _context.Add(game);
        game.GenreNavigation = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == game.Genre);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      else
      {
        foreach (var modelState in ModelState.Values)
        {
          foreach (var error in modelState.Errors)
          {
            Console.WriteLine(error.ErrorMessage);
          }
        }
        ViewBag.Categories = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View(game);
      }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var game = await _context.Games.FindAsync(id);
      if (game == null)
      {
        return NotFound();
      }
      ViewBag.Categories = new SelectList(_context.Genres.ToList(), "GenreId", "Name", game.Genre);
      return View(game);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Game game, IFormFile imageFile)
    {
      if (id != game.Id)
      {
        return NotFound();
      }
      // Get the existing game
      var existingGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
      if (existingGame == null)
      {
        return NotFound();
      }

      ModelState.Remove("imageFile");

      var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
      // Check if the image file is null or empty
      if (imageFile == null || imageFile.Length == 0)
      {
        game.Image = existingGame.Image;
      }
      else
      {
        // Check if the file is an image
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
          ModelState.AddModelError("", "Only .jpg, .png, .jpeg files are allowed!");
        }
        else
        {
          if (imageFile.Length > 100 * 1024 * 1024)
          {
            ModelState.AddModelError("", "File size must be less than 100MB!");
          }
          // Generate a random file name
          var randomFileName = $"{Guid.NewGuid()}{extension}";
          var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
          try
          {
            using (var stream = new FileStream(path, FileMode.Create))
            {
              await imageFile.CopyToAsync(stream);
            }
            game.Image = randomFileName;
          }
          catch
          {
            ModelState.AddModelError("", "There was an error while uploading the image!");
          }
        }
      }
      if (ModelState.IsValid)
      {
        _context.Update(game);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      else
      {
        foreach (var modelState in ModelState.Values)
        {
          foreach (var error in modelState.Errors)
          {
            Console.WriteLine(error.ErrorMessage);
          }
        }
        ViewBag.Categories = new SelectList(_context.Genres.ToList(), "GenreId", "Name", game.Genre);
        return View(game);
      }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var game = await _context.Games.FirstOrDefaultAsync(m => m.Id == id);
      if (game == null)
      {
        return NotFound();
      }

      await SetGenresAsync();

      return View(game);
    }

    // POST: GameController/Delete/id
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var game = await _context.Games.FindAsync(id);

      var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", game.Image);

      try
      {
        System.IO.File.Delete(path);
      }
      catch
      {
        Console.WriteLine("There was an error while deleting the image!");
      }

      _context.Games.Remove(game);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}