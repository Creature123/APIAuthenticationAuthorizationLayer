using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTTokenAuthentication.Models;
using JWTTokenAuthentication.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTTokenAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ITokenManager _itokenmanager;
        public LoginController(ITokenManager tokenManager)
        {
            _itokenmanager = tokenManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> ValidateLogin([FromBody] UserCredential user)
        {
            AuthResult authResult = new AuthResult();

            await Task.Run(() =>
            {
                authResult = _itokenmanager.GenerateToken(user);
            });

            return Ok(
                new
                {
                    token = authResult.token,
                    refreshtoken = authResult.refresh
                }

                );
        }
    }
}

