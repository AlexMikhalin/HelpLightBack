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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository _organizationRepository)
        {
            this._organizationRepository = _organizationRepository;
        }

        // GET: api/Organization
        [HttpPost]
        [Route("UpdateOrgInfo")]
        public IActionResult UpdateOrgInfo([FromBody] Organization orgInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _organizationRepository.UpdateOrganizationInfo(orgInfo);
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
        [Route("GetOrganizationShortInfo/{id:Guid}")]
        public IActionResult GetOrganizationShortInfo(Guid id)
        {
            try
            {
                var shortinfo = _organizationRepository.GetOrganizationInfoById(id);
                return Ok(shortinfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
