using System;
using System.Net;
using Box.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StorageController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Created("storage/xyz", null);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return NoContent();
        }
    }
}

