using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyBus.Data;
using MyBus.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyBus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly SignInManager<Users> _signInManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, SignInManager<Users> signInManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var fromLocations = _context.BusSchedules.Select(b => b.From).Distinct().ToList();
            var toLocations = _context.BusSchedules.Select(b => b.To).Distinct().ToList();
            ViewBag.FromLocations = fromLocations;
            ViewBag.ToLocations = toLocations;
            return View();
        }

        [HttpPost]
        public IActionResult Search(string from, string to, DateTime travelDate, string busType)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                ViewBag.Message = "Please login first to search for bus tickets.";
                var fromLocations = _context.BusSchedules.Select(b => b.From).Distinct().ToList();
                var toLocations = _context.BusSchedules.Select(b => b.To).Distinct().ToList();
                ViewBag.FromLocations = fromLocations;
                ViewBag.ToLocations = toLocations;
                return View("Index");
            }

            var results = _context.BusSchedules
                .Where(b => b.From.ToLower() == from.ToLower() && b.To.ToLower() == to.ToLower() && b.DepartureDate == travelDate)
                .ToList();

            if (busType != "All")
            {
                results = results.Where(b => b.BusType == busType).ToList();
            }

            if (!results.Any())
            {
                ViewBag.Message = "There is no bus available";
            }

            ViewBag.TotalBuses = results.Count;
            ViewBag.TotalSeats = results.Sum(b => b.TotalSeat);

            return View("SearchResults", results);
        }



        [HttpPost]
        public async Task<IActionResult> BookTicket(int busScheduleId, int numberOfTickets)
        {
            var busSchedule = await _context.BusSchedules.FindAsync(busScheduleId);
            if (busSchedule == null || busSchedule.TotalSeat < numberOfTickets)
            {
                return BadRequest("Ticket is insufficient, please reduce the amount.");
            }

            busSchedule.TotalSeat -= numberOfTickets;
            await _context.SaveChangesAsync();

            // Redirect to payment gateway page (this is just a placeholder)
            return RedirectToAction("PaymentGateway");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}