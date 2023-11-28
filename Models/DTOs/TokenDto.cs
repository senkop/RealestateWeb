using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Try.DTOs
{
    public class TokenDto
    {
        [Required]
        public string Token { get; set; }
    }
}
