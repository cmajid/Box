using System;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{
    public class BaseController: ControllerBase
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected int GetUserId() => int.Parse(httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!);

        protected string GetUsername() => httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.Name)!;
	}
}

