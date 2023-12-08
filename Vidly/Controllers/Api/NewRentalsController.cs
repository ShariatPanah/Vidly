using Microsoft.AspNetCore.Mvc;
using Vidly.Core.Domain;
using Vidly.Core.Dtos;
using Vidly.Infrastructure.Data;

namespace Vidly.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var doesCustomerExist = _context.Customers.Any(c => c.Id == newRental.CustomerId);
            if (!doesCustomerExist)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                _context.Rentals.Add(new Rental
                {
                    CustomerId = newRental.CustomerId,
                    MovieId = movie.Id,
                    DateRented = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
