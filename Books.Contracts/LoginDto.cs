﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Contracts
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
