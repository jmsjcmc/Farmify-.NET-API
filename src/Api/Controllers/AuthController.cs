using Farmify_API_v2.src.Core.Interfaces.Repositories;
using Farmify_API_v2.src.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farmify_API_v2.src.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, HttpContext.RequestAborted);
            if (user == null || !user.CheckPassword(request.Password))
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
