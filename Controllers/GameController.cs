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
    public async Task<IActionResult> Create(Game game)
    {
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
    public async Task<IActionResult> Edit(int id, Game game)
    {
      if (id != game.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(game);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!GameExists(game.Id))
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
      return View(game);
    }
  }
}