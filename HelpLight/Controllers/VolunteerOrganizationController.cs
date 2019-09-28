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
    public class VolunteerOrganizationController : ControllerBase
    {
        private readonly IVolunteerOrganizationRepository _volunteerOrganizationRepository;

        public VolunteerOrganizationController(IVolunteerOrganizationRepository _volunteerOrganizationRepository)
        {
            this._volunteerOrganizationRepository = _volunteerOrganizationRepository;
        }

        [HttpGet("GetVolunteersByOrganization/{id:Guid}")]
        public IActionResult GetVolunteersByOrganization(Guid id)
        {
            try
            {
                var volunteers = _volunteerOrganizationRepository.GetVolunteersByOrganization(id);
                return Ok(volunteers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrganizationsByVolunteer/{id:Guid}")]
        public IActionResult GetOrganizationsByVolunteer(Guid id)
        {
            try
            {
                var volunteers = _volunteerOrganizationRepository.GetOrganizationsByVolunteer(id);
                return Ok(volunteers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("JoinOrganization/{id:Guid}")]
        public IActionResult JoinOrganization(Guid id, Guid volunteerId)
        {
            try
            {
                _volunteerOrganizationRepository.JoinOrganization(id, volunteerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
