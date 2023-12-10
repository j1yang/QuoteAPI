using ASP_Web_API.Controllers;
using ASP_Web_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP_Web_API.Services
{
    public class AuthService: IAuthService
    {
        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> LoginUser(LoginRequest loginRequest)
        {
            _user = await _userManager.FindByNameAsync(loginRequest.UserName);

            if (_user == null)
                return false;

            return await _userManager.CheckPasswordAsync(_user, loginRequest.Password);
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterationRequest userRegistrationRequest)
        {
            _user = new User()
            {
                FirstName = userRegistrationRequest.FirstName,
                LastName = userRegistrationRequest.LastName,
                Email = userRegistrationRequest.Email,
                PhoneNumber = userRegistrationRequest.PhoneNumber,
                UserName = userRegistrationRequest.UserName
            };

            var result = await _userManager.CreateAsync(_user, userRegistrationRequest.Password);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRolesAsync(_user, userRegistrationRequest.Roles);
            }

            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secretKeyText = Environment.GetEnvironmentVariable("SECRET");

            if (string.IsNullOrEmpty(secretKeyText))
            {
                throw new InvalidOperationException("The environment variable 'SECRET' is not set or is empty.");
            }

            var key = Encoding.UTF8.GetBytes("This is my top secret key code for getting signing credentials."); //secretKeyText

            // Ensure the key is at least 128 bits (16 bytes)
            if (key.Length < 128 / 8)
            {
                throw new InvalidOperationException("Symmetric key should be at least 128 bits.");
            }

            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        private User? _user;
        private UserManager<User> _userManager;
        private IConfiguration _configuration;
    }
}
