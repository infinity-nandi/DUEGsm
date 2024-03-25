using Microsoft.AspNetCore.Identity;

namespace DUEGsm.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
