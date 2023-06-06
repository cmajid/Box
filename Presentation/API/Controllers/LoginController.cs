using Box.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public LoginResponseModel Post(LoginModel login)
        {
            return new LoginResponseModel { Token = login.Username };
        }
    }
}


