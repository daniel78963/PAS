﻿using System.ComponentModel.DataAnnotations;

namespace PAS.Application.Dto.Account
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
