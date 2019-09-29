using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Cors;

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class KarmaController : ControllerBase
    {
        private readonly IKarmaRepository _karmaRepository;

        public KarmaController(IKarmaRepository _karmaRepository)
        {
            this._karmaRepository = _karmaRepository;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public IActionResult GetMyKarmaHistory(Guid id)
        {
            try
            {
                var history = _karmaRepository.GetMyKarmaHistory(id);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Events
        [HttpPost]
        public IActionResult Post(Guid volunteerId, [FromBody] KarmaHistory history)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _karmaRepository.AddKarma(volunteerId, history.Gained, history.Reason, history.IdEvent);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
