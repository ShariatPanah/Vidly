using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.Domain;
using Vidly.Infrastructure.Data;
using Vidly.Shared;

namespace Vidly.Web.Controllers
{
    [Authorize(Roles = IdentityRoles.CanManageGenres)]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _context.Genres.ToListAsync();
            return View(genres);
        }

        [HttpGet]
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
                return NotFound();

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
                return View(genre);

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
                return NotFound();

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, Genre genre)
        {
            if (id != genre.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(genre);

            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = genre.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
                return NotFound();

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
                return NotFound();

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
