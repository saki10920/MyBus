using Microsoft.EntityFrameworkCore;
using MyBus.Models;

namespace MyBus.Data
{
    public class AppDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
