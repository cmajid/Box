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
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.StaticFiles;

namespace Box.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
 
    public class StorageController : BaseController
    {
        private readonly DataFileService fileService;

        public StorageController(DataFileService fileService, IHttpContextAccessor httpContextAccessor)
            :base(httpContextAccessor)
        {
            this.fileService = fileService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Upload([FromForm] FileRequest fileRequest)
        {
            try
            {
                var file = DataFile.Create(
                        new DataFileArgs {
                            Name = fileRequest.FileName,
                            UserId = GetCurrentUser_UserId(),
                            Username = GetCurrentUser_Username(),
                            PhysicalPath = $"{Directory.GetCurrentDirectory()}/wwwroot/",
                            Size = fileRequest.FormFile.Length.ToSize(FileHelper.SizeUnits.MB)
                        });
                fileService.Save(file);
                UploadFile(fileRequest, file.SystemName);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpGet("{username}/{systemName}")]
        public ActionResult Download(string username, string systemName)
        {
            var file = fileService.DownloadFile(username, systemName);
            var path = file.DownloadByOwner();
            if (System.IO.File.Exists(path))
            {
                var phisycalFile = File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
                phisycalFile.FileDownloadName = file.Name;
                return phisycalFile;
            }
            return NotFound();
        }

        [HttpGet("share/{username}/{systemName}")]
        public ActionResult DownloadShare(string username, string systemName)
        {
            var file = fileService.DownloadFile(username, systemName);
            var path = file.DownloadFile();
            if (System.IO.File.Exists(path))
            {
                var phisycalFile = File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
                phisycalFile.FileDownloadName = file.Name;
                return phisycalFile;
            }
            return NotFound();
        }

        private static void UploadFile(FileRequest file, string systemName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", systemName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.FormFile.CopyTo(stream);
            }
        }

    
    }
}

