using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;

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
            var movies = _context.Movies.ToList();
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
    }
}
