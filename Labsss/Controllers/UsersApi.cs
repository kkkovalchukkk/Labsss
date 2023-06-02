using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourAppName
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
    }

    public static class Repository
    {
        private static List<User> Users { get; } = new List<User>();

        public static List<User> GetData()
        {
            return Users;
        }

        public static User? GetData(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public static void Add(User user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
        }

        public static void Delete(int id)
        {
            User? user = GetData(id);
            if (user != null)
            {
                Users.Remove(user);
            }
        }

        public static void Edit(User user)
        {
            User? existingUser = GetData(user.Id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Login = user.Login;
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> users = Repository.GetData();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User? user = Repository.GetData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            Repository.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult EditUser(int id, [FromBody] User user)
        {
            if (user.Id != id)
            {
                return BadRequest();
            }

            Repository.Edit(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            Repository.Delete(id);
            return Ok();
        }
    }

}
