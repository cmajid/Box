using System;
using Box.Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Box.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DataFileController : ControllerBase
    {
        [HttpPost]
        public bool Post(DataFileDTO dto)
        {
            return false;
        }

        [HttpDelete("{id}")]
        public IActionResult Post(int id)
        {
            return NoContent();
        }

        [HttpGet("{id}")]
        public DataFileDTO Get(string id)
        {
            return new DataFileDTO
            {
                Name = "PeronalPicture1.jpg",
                CreatedDatetime = DateTime.Now,
                Extention = ".jpg",
                Id = Convert.ToInt32(id),
                IsDeleted = false,
                Size = 200,
                SystemName = "XYZ",
                UpdatedDateTime = DateTime.Now,
                UserId = 1,
                UserName = "USERNAME",
            };
        }

        [HttpGet()]
        public List<DataFileDTO> Get()
        {
            return new List<DataFileDTO>(){
                new DataFileDTO
                {
                    Name = "PeronalPicture1.jpg",
                    CreatedDatetime = DateTime.Now,
                    Extention = ".jpg",
                    Id = 1,
                    IsDeleted = false,
                    Size = 200,
                    SystemName = "XYZ",
                    UpdatedDateTime = DateTime.Now,
                    UserId = 1,
                    UserName = "USERNAME",
                },
                new DataFileDTO
                {
                    Name = "PeronalPicture2.jpg",
                    CreatedDatetime = DateTime.Now.AddDays(-5),
                    Extention = ".jpg",
                    Id = 2,
                    IsDeleted = false,
                    Size = 300,
                    SystemName = "XYZ",
                    UpdatedDateTime = DateTime.Now.AddDays(-5),
                    UserId = 1,
                    UserName = "USERNAME",
                },
                new DataFileDTO
                {
                    Name = "PeronalPicture3.jpg",
                    CreatedDatetime = DateTime.Now.AddDays(-15),
                    Extention = ".jpg",
                    Id = 3,
                    IsDeleted = false,
                    Size = 500,
                    SystemName = "XYZ",
                    UpdatedDateTime = DateTime.Now.AddDays(-15),
                    UserId = 1,
                    UserName = "USERNAME",
                }
            };
        }
    }
}

