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
    [Authorize(Roles = IdentityRoles.CanManageGenres)]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres.Select(_mapper.Map<Genre, GenreDto>).ToList();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(byte id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
                return NotFound();

            return _mapper.Map<Genre, GenreDto>(genre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(byte id, GenreDto genreDto)
        {
            if (id != genreDto.Id)
                return BadRequest();

            var genre = _mapper.Map<GenreDto, Genre>(genreDto);
            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenreDto>> PostGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<GenreDto, Genre>(genreDto);
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            genreDto = _mapper.Map<Genre, GenreDto>(genre);
            return CreatedAtAction(nameof(GetGenre), new { id = genreDto.Id }, genreDto);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(byte id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(byte id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
