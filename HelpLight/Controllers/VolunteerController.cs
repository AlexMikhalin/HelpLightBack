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

namespace HelpLight.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
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
            try
            {
                var userId = Request.Headers["token"].ToString();
                _volunteerRepository.ValidateVolunteer(new Guid(userId), volunteer.IdVolunteer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
        [HttpPut]
        [Route("AddSkillsToVolunteer")]
        public IActionResult Put(Guid volunteerId, [FromBody] List<Skill> skills)
        {
            try
            {
                var userId = Request.Headers["token"].ToString();
                _volunteerRepository.ValidateVolunteer(new Guid(userId), volunteerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                _volunteerRepository.AddSkillsToVolunteer(volunteerId, skills);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
