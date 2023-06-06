using Box.API.Models;
using Box.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost("register")]
        public ActionResult<LoginResponse> Register(LoginRequest request)
        {
            return Ok(new LoginResponse { Token = string.Empty});
        }

        [HttpPost]
        public LoginResponse Post(LoginRequest login)
        {
            return new LoginResponse { Token = login.Username };
        }
    }
}


