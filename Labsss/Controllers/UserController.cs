// UserController.cs
using System.Collections.Generic;
using Labsss.Data;
using Labsss.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labsss.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryInMemory _userRepository;

        public UserController(IUserRepositoryInMemory userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<User> users = _userRepository.GetData();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _userRepository.GetData(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            User existingUser = _userRepository.GetData(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Edit(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User existingUser = _userRepository.GetData(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            return NoContent();
        }
    }
}