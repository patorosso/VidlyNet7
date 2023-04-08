using Microsoft.AspNetCore.Mvc;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/movies/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(_context.Movies.ToList());
        }


        // GET /api/movies/id
        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Movie> GetMovie(int id)
        {
            if (id == 0)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }


        // POST /api/movies
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Movie> PostMovie([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest(movie);

            if (movie.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);


            _context.Movies.Add(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);


        }



    }
}
