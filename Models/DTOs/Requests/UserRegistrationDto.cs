using System.ComponentModel.DataAnnotations;

namespace Try.Models.DTOs.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FistName { get; set; }
        public string phone { get; set; }
    }
}