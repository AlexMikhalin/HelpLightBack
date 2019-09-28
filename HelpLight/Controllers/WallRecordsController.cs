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
    public class WallRecordsController : ControllerBase
    {
        private readonly IWallRepository _wallRepository;

        public WallRecordsController(IWallRepository _wallRepository)
        {
            this._wallRepository = _wallRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] WallRecord newWallRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _wallRepository.AddRecord(newWallRecord);
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

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var records = _wallRepository.GetRecords(id);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
