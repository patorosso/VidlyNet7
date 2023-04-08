﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Models;

namespace VidlyNet7.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext _db)
        {
            _context = _db;
        }


        // GET /api/movies/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(_context.Movies.ToList());
        }


        // GET /api/movies/id
        [HttpGet("{id:int}")]
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (movie == null)
                return BadRequest(movie);

            if (movie.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var dbId = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);

            if (dbId != null && movie.Id == dbId.Id)
            {
                ModelState.AddModelError("Id existente", "Ya existe este id, por favor pruebe otro.");
                return BadRequest(ModelState);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }


        // PUT /api/movies/id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id || movie == null)
                return BadRequest();

            var movieInDb = _context.Movies.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Update(movie);
            _context.SaveChanges();
            return NoContent();
        }


        // DELETE /api/movies/id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMovie(int id)
        {
            if (id == 0)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.ExecuteDeleteAsync();

            return NoContent();
        }





    }
}
