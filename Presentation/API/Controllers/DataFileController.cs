﻿using System;
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
        public ActionResult<List<DataFileDTO>> Get()
        {
            var result = fileService.GetAll(GetUserId());
            return result;
        }
    }
}

