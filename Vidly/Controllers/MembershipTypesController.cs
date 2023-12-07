using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.Domain;
using Vidly.Infrastructure.Data;

namespace Vidly.Web.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var types = await _context.MembershipTypes.ToListAsync();

            return View(types);
        }

        [HttpGet]
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
                return NotFound();

            var membershipType = await _context.MembershipTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
                return NotFound();

            return View(membershipType);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembershipType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _context.MembershipTypes.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
                return NotFound();

            var membershipType = await _context.MembershipTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
                return NotFound();

            return View(membershipType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, MembershipType model)
        {
            if (model.Id != id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
                return NotFound();

            var membershipType = await _context.MembershipTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
                return NotFound();

            return View(membershipType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var membershipType = await _context.MembershipTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
                return NotFound();

            _context.MembershipTypes.Remove(membershipType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
