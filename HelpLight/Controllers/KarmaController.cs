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
    public class KarmaController : ControllerBase
    {
        private readonly IKarmaRepository _karmaRepository;

        public KarmaController(IKarmaRepository _karmaRepository)
        {
            this._karmaRepository = _karmaRepository;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
