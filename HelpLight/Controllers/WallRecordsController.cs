using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;

namespace VaMHelper.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class WallRecordsController : ControllerBase
    {
        private readonly IWallRepository _wallRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public WallRecordsController(IWallRepository _wallRepository, IHostingEnvironment environment)
        {
            this._wallRepository = _wallRepository;
            hostingEnvironment = environment;
        }

        [HttpPost]
        public IActionResult Post([FromBody] WallRecord newWallRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _wallRepository.AddRecord(newWallRecord);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var records = _wallRepository.GetRecords(id);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult PostFile(IFormFile uploadedFile)
        {
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var newFileName = GetUniqueFileName(uploadedFile.FileName);
            var fullPath = Path.Combine(uploads, newFileName);

            uploadedFile.CopyTo(new FileStream(fullPath, FileMode.OpenOrCreate));

            return Ok(newFileName);
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
}
