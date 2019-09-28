using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class AnalyserController : ControllerBase
    {
        [HttpGet]
        [Route("Analyze")]
        public IActionResult Analyze()
        {
            try
            {
                Random random = new Random();
                int VolunteersAmount = random.Next(100, 300);

                var excellentReaction = 0;
                var goodReaction = 0;
                var okReaction = 0;
                var badReaction = 0;

                for (var i = 0; i < VolunteersAmount; i++)
                {
                    Random random2 = new Random();
                    int reaction = random2.Next(1, 5);


                    switch(reaction)
                    {
                        case 1:    excellentReaction++;  break;
                        case 2:    goodReaction++;   break;
                        case 3:    okReaction++; break;
                        case 4:    badReaction++;  break;
                    }
                }

                var lastMonthAverageReaction = 4.5;
                var lsatYearAverageReaction = 4.2;
                var countOfBurnedLastMonth = 8;
                var countOfNewVolonteers = 23;

                return Ok( new { VolunteersAmount , excellentReaction, goodReaction, okReaction, badReaction, lastMonthAverageReaction, lsatYearAverageReaction, countOfBurnedLastMonth, countOfNewVolonteers } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}