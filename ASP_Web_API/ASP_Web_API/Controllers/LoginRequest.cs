﻿using System.ComponentModel.DataAnnotations;

namespace ASP_Web_API.Controllers
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
