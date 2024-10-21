using GameTrack.Data;
using GameTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameTrack.Controllers
{
  public class GenreController : Controller
  {
    protected readonly ApplicationDbContext _context;

    public GenreController(ApplicationDbContext context)
    {
      _context = context;
    }

    // Check if a genre exists
    private bool GenreExists(int id)
    {
      return _context.Genres.Any(e => e.GenreId == id);
    }

    [HttpGet]
    public IActionResult Index()
    {
      var genres = _context.Genres.ToList();
      return View(genres);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Genre genre)
    {
      if (ModelState.IsValid)
      {
        // Add the genre to the database if model is valid
        _context.Add(genre);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(genre);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var genre = await _context.Genres.FindAsync(id);
      if (genre == null)
      {
        return NotFound();
      }

      return View(genre);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Genre genre)
    {
      if (id != genre.GenreId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(genre);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!GenreExists(genre.GenreId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }

      return View(genre);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var genre = await _context.Genres.FirstOrDefaultAsync(m => m.GenreId == id);
      if (genre == null)
      {
        return NotFound();
      }

      return View(genre);
    }

    // POST: Genres/Delete/id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      // Delete the genre
      var genre = await _context.Genres.FindAsync(id);
      if (genre != null)
      {
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
      }

      return RedirectToAction(nameof(Index));
    }
  }
}