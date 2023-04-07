using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Edit(int id) => Content("id=" + id);

        public IActionResult Index()
        {
            List<Movie> movies = new()
            {
                new Movie { Id= 1, Name = "Shrek" },
                new Movie { Id= 2, Name = "Wall-e" }
            };

            return View(movies);
        }
    }
}
