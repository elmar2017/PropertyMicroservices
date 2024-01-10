using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Property.API.Dtos.User;
using Property.API.Services.Interfaces;

namespace Property.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;


        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }


        // POST api/<HomeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDto loginDto)
        {
            IActionResult response = Unauthorized();
            var user = await _userService.GetAsync(loginDto.Email);

            if (user != null && user.Password == loginDto.Password)
            {
                var tokenString = _jwtService.GenerateJwtToken(loginDto.Email);
                response = Ok(new { token = tokenString });
            }

            return response;

        }


    }
}
