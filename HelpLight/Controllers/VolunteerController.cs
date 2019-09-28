using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace VaMHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerReporitory _volunteerRepository;

        private readonly IHostingEnvironment hostingEnvironment;

        public VolunteerController(IVolunteerReporitory _volunteerRepository, IHostingEnvironment environment)
        {
            this._volunteerRepository = _volunteerRepository;
            hostingEnvironment = environment;
        }

        // GET: api/Volunteer/5
        [HttpGet("{id:Guid}")]
        public IActionResult GetVolunteerShortInfoById(Guid id)
        {
            try
            {
                var volunteer = _volunteerRepository.GetVolunteerInfoById(id);
                return Ok(volunteer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateVolunteerInfo")]
        public IActionResult Post([FromBody] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _volunteerRepository.UpdadeVolunteerInfo(volunteer);
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


        [HttpPost]
        [Route("upload")]
        public IActionResult PostFile(IFormFile uploadedFile)
        {
            var filePath = Path.GetTempFileName();
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var fullPath = Path.Combine(uploads, GetUniqueFileName(uploadedFile.FileName));

            uploadedFile.CopyTo(new FileStream(fullPath, FileMode.OpenOrCreate));

            return Ok(fullPath);
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
