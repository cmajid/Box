using System;
using Box.Contract.DTOs;
using Box.Contract.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DataFileController : BaseController
    {
        private readonly DataFileService fileService;

        public DataFileController(DataFileService fileService, IHttpContextAccessor httpContextAccessor)
            :base(httpContextAccessor)
        {
            this.fileService = fileService;
        }

        [HttpGet()]
        public ActionResult<List<DataFileDTO>> GetAllFiles()
        {
            var result = fileService.GetAll(GetCurrentUser_UserId());
            return result;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<DataFileDTO>> Delete(int id)
        {
            fileService.Delete(id);
            return NoContent();
        }
    }
}

