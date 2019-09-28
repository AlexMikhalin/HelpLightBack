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
    public class BanController : ControllerBase
    {
        private readonly IBanRepository _banRepository;

        public BanController(IBanRepository _banRepository)
        {
            this._banRepository = _banRepository;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetAllBannedVolunteersByOrganizationId(Guid id)
        {
            try
            {
                var banned = _banRepository.GetAllBannedVolunteersByOrganizationId(id);
                return Ok(banned);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
