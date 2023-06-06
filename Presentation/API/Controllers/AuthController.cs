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
        public ActionResult<LoginResponse> Register(LoginRequest request)
        {
            var user = CreateUser(request);
            userService.Register(user);
            return Ok(new LoginResponse { Token = user.PasswordHash });
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            User user = CreateUser(request);
            userService.VerifyUser(user);
            var token = CreateToken(user);
            return new LoginResponse { Token = token };
        }

        private User CreateUser(LoginRequest request)
        {
            var passwordHash = HashHelper.GetPasswordHash(request.Password);
            var user = Domain.Entities.User.Create(
                    new UserArgs(request.Username, passwordHash));
            return user;
        }

        private string CreateToken(User user)
        {
            var key = configuration.GetSection("AppSettings:Token").Value!;
            var token = HashHelper.CreateToken(key, user.Username);
            return token;
        }
    }
}


