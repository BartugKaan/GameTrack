using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GameTrack.Models;
using GameTrack.Data;

namespace GameTrack.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var games = _context.Games.ToList();
        foreach (var game in games)
        {
            game.GenreNavigation = _context.Genres.FirstOrDefault(g => g.GenreId == game.Genre);
        }
        return View(games);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
