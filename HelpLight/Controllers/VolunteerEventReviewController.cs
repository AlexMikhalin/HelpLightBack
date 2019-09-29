using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Cors;

namespace HelpLight.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class VolunteerEventReviewController : ControllerBase
    {
        private readonly IVolunteerEventReviewRepository _volunteerEventReviewRepository;

        public VolunteerEventReviewController(IVolunteerEventReviewRepository _volunteerEventReviewRepository)
        {
            this._volunteerEventReviewRepository = _volunteerEventReviewRepository;
        }

        [HttpGet]
        [Route("GetEventReviews")]
        public IActionResult GetEventReviews(Guid eventId)
        {
            try
            {
                var reviews = _volunteerEventReviewRepository.GetEventReviews(eventId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ReviewEvent")]
        public IActionResult Post([FromBody] VolunteerEventReview review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _volunteerEventReviewRepository.ReviewEvent(review);
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
