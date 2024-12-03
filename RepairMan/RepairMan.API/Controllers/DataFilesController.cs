// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Authorization;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepairMan.Business.Common;
using RepairMan.DataClasses.Common;
using RepairMan.Services.Common;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFilesController : ControllerBase
    {
        private readonly IDataFileService _service;
        private readonly IUserControlLogic _userControlLogic;

        public DataFilesController(IDataFileService service, IUserControlLogic userControlLogic)
        {
            _service = service;
            _userControlLogic = userControlLogic;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var dataFile = _service.GetFile(id);
            if (dataFile == null)
            {
                return NotFound();
            }


            return File(dataFile.Content, dataFile.ContentType);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create([FromForm] IFormFile file)
        {
            if (file != null)
            {
                User signedUser = _userControlLogic.GetUserByIdentity(User.Identity);
                DataFile dataFile = _service.GetFile(x => x.Length == file.Length && x.UserId == signedUser.UserId);

                if (dataFile == null)
                {
                    var stream = new MemoryStream();
                    file.CopyTo(stream);

                    dataFile = new DataFile()
                    {
                        Name = file.Name,
                        ContentType = file.ContentType,
                        Length = file.Length,
                        Content = stream.ToArray(),
                        UserId = signedUser.UserId
                    };

                    _service.Create(dataFile);
                }

                return Ok(dataFile);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
