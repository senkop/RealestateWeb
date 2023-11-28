using System.Collections.Generic;

namespace Try.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string userid { get; set; }
        public string email { get; set; }

    }
}