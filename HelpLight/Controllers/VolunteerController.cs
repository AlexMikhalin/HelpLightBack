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
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerReporitory _volunteerRepository;

        public VolunteerController(IVolunteerReporitory _volunteerRepository)
        {
            this._volunteerRepository = _volunteerRepository;
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

    }
}
