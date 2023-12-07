using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.Domain;
using Vidly.Infrastructure.Data;
using Vidly.Shared;

namespace Vidly.Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(IdentityRoles.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
                return View(movie);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (movie.Id != id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
                return View(movie);
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = movie.Id });
        }

        [HttpGet]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = IdentityRoles.CanManageMovies)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
