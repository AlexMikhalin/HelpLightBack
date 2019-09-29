using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public OrganizationController(IOrganizationRepository _organizationRepository, IHostingEnvironment environment)
        {
            this._organizationRepository = _organizationRepository;
            hostingEnvironment = environment;
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
