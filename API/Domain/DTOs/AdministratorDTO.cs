using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs
{
    public class AdministratorDTO
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Profile Profile { get; set; } = default!; 
    }
}