using ASP_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using ASP_Web_API.Services;
using ASP_Web_API.Models;
using Newtonsoft.Json;

namespace ASP_Web_API.Controllers
{
    [ApiController()]
    public class AccountApiController : Controller
    {
        public AccountApiController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/api/register")]
        public async Task<IActionResult> RegisterUser(UserRegisterationRequest userRegisterationRequest)
        {
            Console.WriteLine($"Received JSON: {JsonConvert.SerializeObject(userRegisterationRequest)}");

            if (userRegisterationRequest == null || string.IsNullOrEmpty(userRegisterationRequest.Password))
            {
                // Handle the case where the request or password is null
                return BadRequest("Invalid request or password");
            }

            var result = await _authService.RegisterUser(userRegisterationRequest);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.TryAddModelError(err.Code, err.Description);
                }

                return BadRequest(ModelState);
            }
        }


        [HttpPost("/api/login")]
        public async Task<IActionResult> LoginUser(LoginRequest loginRequest)
        {
            Console.WriteLine($"Received JSON: {JsonConvert.SerializeObject(loginRequest)}");

            bool isValidUser = await _authService.LoginUser(loginRequest);

            if (isValidUser)
            {
                return Ok(new { Token = await _authService.CreateToken() });
            }
            else
            {
                return Unauthorized();
            }
        }

        private IAuthService _authService;
    }
}
