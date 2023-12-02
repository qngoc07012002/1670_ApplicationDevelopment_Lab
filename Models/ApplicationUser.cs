using Microsoft.AspNetCore.Identity;

namespace _1670_ApplicationDevelopment_Lab.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        
    }
}
