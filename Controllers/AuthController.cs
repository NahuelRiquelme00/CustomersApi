using CustomersApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAuthService _authService;

        public AuthController(IJwtService jwtService, IAuthService authService)
        {
            _jwtService = jwtService;
            _authService = authService; 
        }

        [HttpPost("gettoken")]
        public IActionResult getToken(string username)
        {
            var token = _jwtService.generateToken(username);
            return Ok(token);
        }

        [HttpPost("auth")]
        public async Task<Auth> Auth(string username, string password)
        {          
           return await _authService.Auth(username, password);
        }

    }
}
