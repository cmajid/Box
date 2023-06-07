using System;
using System.IO;
using System.Net;
using System.Security.Claims;
using Box.API.Models;
using Box.Contract.Interfaces.Services;
using Box.Domain.Args;
using Box.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Box.Infrastructure.Files;

namespace Box.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StorageController : BaseController
    {
        private readonly DataFileService fileService;

        public StorageController(DataFileService fileService, IHttpContextAccessor httpContextAccessor)
            :base(httpContextAccessor)
        {
            this.fileService = fileService;
        }

        [HttpPost]
        public IActionResult Post([FromForm] FileRequest fileRequest)
        {
            try
            {
                UploadFile(fileRequest);
                var file = DataFile.Create(
                        new DataFileArgs {
                            Name = fileRequest.FileName,
                            UserId = GetUserId(),
                            Username = GetUsername(),
                            PhysicalPath = $"{Directory.GetCurrentDirectory()}/wwwroot",
                            Size = fileRequest.FormFile.Length.ToSize(FileHelper.SizeUnits.MB)
                        });
                fileService.Save(file);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private static void UploadFile(FileRequest file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.FormFile.CopyTo(stream);
            }
        }

    
    }
}

