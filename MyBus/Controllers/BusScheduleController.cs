using Microsoft.AspNetCore.Mvc;
using MyBus.Data;
using MyBus.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyBus.Controllers
{
    public class BusScheduleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BusScheduleController> _logger;

        public BusScheduleController(AppDbContext context, ILogger<BusScheduleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BusSchedules.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusSchedule busSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busSchedule);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var busSchedule = await _context.BusSchedules.FindAsync(id);
            if (busSchedule == null)
            {
                return NotFound();
            }
            return View(busSchedule);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BusSchedule busSchedule)
        {
            if (id != busSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(busSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busSchedule);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var busSchedule = await _context.BusSchedules.FindAsync(id);
            if (busSchedule == null)
            {
                return NotFound();
            }
            return View(busSchedule);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInformation("Attempting to delete bus schedule with ID {Id}", id);
            var busSchedule = await _context.BusSchedules.FindAsync(id);
            if (busSchedule == null)
            {
                _logger.LogWarning("Bus schedule with ID {Id} not found", id);
                return NotFound();
            }

            _context.BusSchedules.Remove(busSchedule);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Bus schedule with ID {Id} deleted successfully", id);
            return RedirectToAction(nameof(Index));
        }
    }
}
