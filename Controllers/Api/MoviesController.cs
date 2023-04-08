using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Dtos;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET /api/movies/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            IEnumerable<Movie> movieList = await _context.Movies.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movieList));
        }


        // GET /api/movies/id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            if (id == 0)
                return BadRequest();

            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<MovieDto>(movie));
        }


        // POST /api/movies
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> PostMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (movieDto == null)
                return BadRequest(movieDto);

            if (movieDto.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var dbId = await _context.Movies.SingleOrDefaultAsync(c => c.Id == movieDto.Id);

            if (dbId != null && movieDto.Id == dbId.Id)
            {
                ModelState.AddModelError("Id existente", "Ya existe este id, por favor pruebe otro.");
                return BadRequest(ModelState);
            }

            Movie postedMovie = _mapper.Map<Movie>(movieDto); // creo un modelo de Movie usando el movieDto del param de la func

            await _context.Movies.AddAsync(postedMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movieDto.Id }, movieDto);
        }


        // PUT /api/movies/id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (id != movieDto.Id || movieDto == null)
                return BadRequest();

            var movieInDb = await _context.Movies.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (movieInDb == null)
                return NotFound();

            Movie updatedMovie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Update(updatedMovie);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // DELETE /api/movies/id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (id == 0)
                return BadRequest();

            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }





    }
}
