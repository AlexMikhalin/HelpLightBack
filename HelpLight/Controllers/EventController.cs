using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace VaMHelper.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public EventController(IEventRepository _eventRepository, IHostingEnvironment environment)
        {
            this._eventRepository = _eventRepository;
            hostingEnvironment = environment;
        }

        // GET: api/Events/5
        [HttpGet, Route("{id}")]
        public IActionResult GetAllOrganizationEvents(Guid id)
        {
            try
            {
                var orgEvents = _eventRepository.GetAllEventsByOrganizationId(id);
                return Ok(orgEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllOrganizationEvents")]
        public IActionResult GetVolunteersAppliedForEvent(Guid id, [FromBody] bool onlyApproved)
        {
            try
            {
                var orgEvents = _eventRepository.GetVolunteersAppliedForEvent(id, onlyApproved);
                return Ok(orgEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent([FromBody] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _eventRepository.CreateEvent(newEvent);
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

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteEvent(Guid id)
        {
            try
            {
                _eventRepository.DeleteEvent(id);
                return Ok();
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
