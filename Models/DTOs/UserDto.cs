
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Try.Models.DTOs;

namespace Try.Models.Core.DTOs
{
    public class UserDto : IValidatableDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
