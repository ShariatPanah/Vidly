using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.Domain;
using Vidly.Core.Dtos;
using Vidly.Infrastructure.Data;
using Vidly.Shared;

namespace Vidly.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(_mapper.Map<Movie, MovieDto>).ToList();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return _mapper.Map<Movie, MovieDto>(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<ActionResult<Movie>> PostMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            movieDto = _mapper.Map<Movie, MovieDto>(movie);
            return CreatedAtAction("GetMovie", new { id = movieDto.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
