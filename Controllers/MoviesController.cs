using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Models;
using VidlyNet7.ViewModels;

namespace VidlyNet7.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public IActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        [Route("Movies/Details/{paramId}")]
        public IActionResult Details(int paramId)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == paramId);

            if (movie != null)
                return View(movie);
            else return NotFound();




        }

        public IActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }

    }
}
