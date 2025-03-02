using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBus.Models;

namespace MyBus.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BusSchedule> BusSchedules { get; set; }
    }
}