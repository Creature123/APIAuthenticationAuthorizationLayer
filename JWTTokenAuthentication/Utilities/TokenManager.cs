using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTTokenAuthentication.Common;
using JWTTokenAuthentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace JWTTokenAuthentication.Utilities
{
    public class TokenManager : ITokenManager
    {
        

        public AuthResult GenerateToken(dynamic user)
        {
            AuthResult authResult = new AuthResult();

            // initialize token handler

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dadasdasddadadsadadas");

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim("Email", user.EmailID),
                            new Claim("UserName", user.UserName)
                        }
                        ),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
                    Audience = Settings.Instance.Appsetings.JWTAudience,
                    Issuer = Settings.Instance.Appsetings.JWTIssuer
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                authResult.token = tokenHandler.WriteToken(token);

                authResult.refresh = new Guid().ToString();

            }
            catch(Exception)
            {
                return null;
            }



            return authResult;
        }
    }
}

