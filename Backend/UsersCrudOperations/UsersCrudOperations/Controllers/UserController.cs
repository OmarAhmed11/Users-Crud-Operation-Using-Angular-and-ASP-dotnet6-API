using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UsersCrudOperations.Data;

namespace UsersCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        public UserController(DataContext _context) {
              context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(context.user.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            context.user.Add(user);
            await context.SaveChangesAsync();

            return Ok(context.user.ToList());
        }
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {

            var myUser = await context.user.FindAsync(user.id);
            if(myUser == null)
            {
                return BadRequest("Hero Not Found");
            }
            myUser.nickName = user.nickName;
            myUser.firstName = user.firstName;
            myUser.lastName = user.lastName;
            myUser.country = user.country;
            myUser.phone = user.phone;

            await context.SaveChangesAsync();

            return Ok(context.user.ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var myUser = await context.user.FindAsync(id);
            if(myUser == null)
            {
                return BadRequest("No User Found");
            }

            context.user.Remove(myUser);

            await context.SaveChangesAsync();

            return Ok(context.user.ToList());
        }
    }
}
