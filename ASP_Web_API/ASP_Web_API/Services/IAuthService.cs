using ASP_Web_API.Controllers;
using Microsoft.AspNetCore.Identity;

namespace ASP_Web_API.Services
{
    public interface IAuthService
    {
        public Task<IdentityResult> RegisterUser(UserRegisterationRequest userRegistrationRequest);
        public Task<bool> LoginUser(LoginRequest loginRequest);
        public Task<string> CreateToken();
    }
}
