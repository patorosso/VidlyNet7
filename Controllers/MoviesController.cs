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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                var genres = _context.Genres.ToList();

                var viewModel = new MovieFormViewModel
                {
                    Genres = genres,
                    Movie = movie
                };
                return View(viewModel);
            }


        }

        public IActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View(viewModel);
        }
        [HttpGet]
        [Route("Movies/Edit/{paramId}")]
        public IActionResult Edit(int? paramId)
        {
            if (paramId == null)
                return NotFound();

            var movie = _context.Movies.Find(paramId);

            if (movie == null)
                return NotFound();

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                if (movieInDb == null)
                    return NotFound();

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;


                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                var genres = _context.Genres.ToList();

                var viewModel = new MovieFormViewModel
                {
                    Genres = genres,
                    Movie = movie
                };
                return View(viewModel);
            }



        }



    }
}
