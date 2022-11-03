using System;
using JWTTokenAuthentication.Models;

namespace JWTTokenAuthentication.Utilities
{
    public interface ITokenManager
    {
        AuthResult GenerateToken(dynamic user);
    }
}

