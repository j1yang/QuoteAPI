namespace ASP_Web_API.Controllers
{
    public class UserRegisterationRequest : LoginRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<string>? Roles { get; set; }
    }
}
