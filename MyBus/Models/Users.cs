using Microsoft.AspNetCore.Identity;

namespace MyBus.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }

    }
}
