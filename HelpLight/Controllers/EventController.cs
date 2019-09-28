using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;

namespace VaMHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository _eventRepository)
        {
            this._eventRepository = _eventRepository;
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
    }
}
