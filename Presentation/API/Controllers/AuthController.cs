using System.Security.Claims;
using System.Text;
using Box.API.Models;
using Box.Contract.Interfaces.Services;
using Box.Domain.Args;
using Box.Domain.Entities;
using Box.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Box.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;
        private readonly IConfiguration configuration;
        public AuthController(UserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult Register(LoginRequest request)
        {
            var passwordHash = HashHelper.GetPasswordHash(request.Password);
            var user = Domain.Entities.User.Create(
                    new UserArgs(request.Username, passwordHash));
            userService.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            var user = userService.VerifyUser(request.Username, request.Password);
            var token = CreateToken(user);
            return new LoginResponse { Token = token };
        }
  
        private string CreateToken(User user)
        {
            var key = configuration.GetSection("AppSettings:SecureKey").Value!;
            var token = HashHelper.CreateToken(key,user.Id, user.Username);
            return token;
        }
    }
}


