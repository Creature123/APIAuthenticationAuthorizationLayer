using System;
namespace JWTTokenAuthentication.Models
{
    public record AuthResult
    {

        public string token;
        public string refresh;
    
    }
}

