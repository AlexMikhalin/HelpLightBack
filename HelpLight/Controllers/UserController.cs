using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        // DODO:
        // Danger!!!
        // Only for testing now!
        // Delete later!
        //[HttpGet]
        ////[Route("GetAllUsers")]
        //public IActionResult GetAllUsers()
        //{
        //    try
        //    {
        //        var data = _userRepository.GetAllUsers();
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.AddUser(user);
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
        [Route("LoginUser")]
        public IActionResult LoginUser(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loggedInUserId = _userRepository.LoginUser(user);
                    return Ok(loggedInUserId);
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
        [Route("GetUserInfo")]
        public IActionResult Get(Guid userId)
        {
            try
            {
                var usertologID = Request.Headers["token"].ToString();
                if (!((new Guid(usertologID)) == userId))
                {
                    return BadRequest("You don't know secret ...");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                var user = _userRepository.GetUser(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
