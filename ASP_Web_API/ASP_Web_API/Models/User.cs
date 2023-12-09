using Microsoft.AspNetCore.Identity;

namespace ASP_Web_API.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
