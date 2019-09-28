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
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository _cardRepository)
        {
            this._cardRepository = _cardRepository;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetCardByVolunteerId(Guid id)
        {
            try
            {
                var card = _cardRepository.GetCardByVolunteerId(id);
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id:Guid}")]
        public IActionResult AddCardToVolunteer(Guid id, [FromBody] Card card)
        {
            if (ModelState.IsValid)
            {
                _cardRepository.AddCardToVolunteer(id, card);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
