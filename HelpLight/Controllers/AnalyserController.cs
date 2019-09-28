﻿using System;
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
                int VolunteersAmount = 294;
                var excellentReaction = 78;
                var goodReaction = 86;
                var okReaction = 75;
                var badReaction = 55;
                var lastMonthAverageReaction = 4.5;
                var lsatYearAverageReaction = 4.2;
                var countOfBurnedLastMonth = 8;
                var countOfNewVolonteers = 23;

                return Ok( new { VolunteersAmount ,
                                excellentReaction,
                                goodReaction,
                                okReaction,
                                badReaction,
                                lastMonthAverageReaction,
                                lsatYearAverageReaction,
                                countOfBurnedLastMonth,
                                countOfNewVolonteers } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}