using GameTrack.Data;
using GameTrack.Models;
using Microsoft.AspNetCore.Mvc;
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
      return _context.Game.Any(e => e.Id == id);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      return View(await _context.Game.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Game game, IFormFile imageFile)
    {

      var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };

      if (imageFile != null)
      {
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!allowenExtensions.Contains(extension))
        {
          ModelState.AddModelError("", "Only .jpg, .png, .jpeg files are allowed!");
        }
        else
        {
          if (imageFile.Length > 100 * 1024 * 1024)
          {
            ModelState.AddModelError("", "File size must be less than 100MB!");
          }
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
        _context.Add(game);
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

      var game = await _context.Game.FindAsync(id);
      if (game == null)
      {
        return NotFound();
      }

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

      var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };

      if (imageFile != null)
      {
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!allowenExtensions.Contains(extension))
        {
          ModelState.AddModelError("", "Only .jpg, .png, .jpeg files are allowed!");
        }
        else
        {
          if (imageFile.Length > 100 * 1024 * 1024)
          {
            ModelState.AddModelError("", "File size must be less than 100MB!");
          }
          var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
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
            Console.WriteLine("Bir hata oluştu");
          }
        }
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

      var game = await _context.Game.FirstOrDefaultAsync(m => m.Id == id);
      if (game == null)
      {
        return NotFound();
      }

      return View(game);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var game = await _context.Game.FindAsync(id);
      _context.Game.Remove(game);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}