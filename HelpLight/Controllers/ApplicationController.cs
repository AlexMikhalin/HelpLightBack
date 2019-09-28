using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Cors;

namespace VaMHelper.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationController(IApplicationRepository _applicationRepository)
        {
            this._applicationRepository = _applicationRepository;
        }

        // POST: api/Events
        [HttpPost]
        [Route("CreateApplication")]
        public IActionResult Post([FromBody] Application application)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _applicationRepository.CreateApplication(application);
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
        [Route("UpdateApplication")]
        public IActionResult UpdateApplication([FromBody] Application application)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _applicationRepository.UpdateApplication(application);
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

        [HttpGet]
        [Route("ApproveApplication")]
        public IActionResult ApproveApplication(Guid applicationId)
        {
            try
            {
                _applicationRepository.ApproveApplication(applicationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RejectApplication")]
        public IActionResult RejectApplication(Guid applicationId)
        {
            try
            {
                _applicationRepository.RejectApplication(applicationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetApplicationsByVolunteerID")]
        public IActionResult GetApplicationsByVolunteerID(Guid volunteerId)
        {
            try
            {
                var applications = _applicationRepository.GetApplicationsByVolunteerId(volunteerId);
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetApplicationsByEventId")]
        public IActionResult GetApplicationsByEventId(Guid eventId)
        {
            try
            {
                var applications = _applicationRepository.GetApplicationsByEventId(eventId);
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RecallApplication")]
        public IActionResult RecallApplication(Guid applicationId)
        {
            try
            {
                _applicationRepository.RecallApplication(applicationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("WasOnEvent")]
        public IActionResult WasOnEvent(Guid applicationId)
        {
            try
            {
                _applicationRepository.WasOnEvent(applicationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _applicationRepository.DeleteApplication(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
