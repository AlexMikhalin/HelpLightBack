using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
        //[Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var data = _userRepository.GetAllUsers();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
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
                    _userRepository.LoginUser(user);
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
