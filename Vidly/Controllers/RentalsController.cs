using Microsoft.AspNetCore.Mvc;

namespace Vidly.Web.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
