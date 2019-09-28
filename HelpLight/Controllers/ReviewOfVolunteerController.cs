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
    public class ReviewOfVolunteerController : ControllerBase
    {
        private readonly IReviewOfVolunteerRepository _reviewOfVolunteerRepository;

        public ReviewOfVolunteerController(IReviewOfVolunteerRepository _reviewOfVolunteerRepository)
        {
            this._reviewOfVolunteerRepository = _reviewOfVolunteerRepository;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetReviewsOfVolunteer(Guid id)
        {
            try
            {
                var reviews = _reviewOfVolunteerRepository.GetReviewsOfVolunteer(id);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddVolunteerReview")]
        public IActionResult Post([FromBody] ReviewOfVolunteer review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _reviewOfVolunteerRepository.AddReviewOfVolunteer(review);
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
