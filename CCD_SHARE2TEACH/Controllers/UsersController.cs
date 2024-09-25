using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/USERS")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _usersContext;

        public UsersController(UsersDbContext usersContext)
        {
            _usersContext = usersContext;
        }

        // Get : api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<USERS>>> GetUsers()
        {
            if (_usersContext.USERS == null)
            {
                return NotFound();
            }
            return await _usersContext.USERS.ToListAsync();
        }

        // Get : api/Users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<USERS>> GetUser(int id)
        {
            if (_usersContext.USERS is null)
            {
                return NotFound();
            }
            var uservar = await _usersContext.USERS.FindAsync(id);
            if (uservar is null)
            {
                return NotFound();
            }
            return uservar;
        }

        // Post : api/Users
        [HttpPost]
        public async Task<ActionResult<USERS>> PostUser(USERS user)
        {
            _usersContext.USERS.Add(user);
            await _usersContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // Put : api/USERS/2
        [HttpPut]
        public async Task<ActionResult<USERS>> PutUser(int id, USERS user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _usersContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _usersContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool UserExists(long id)
        {
            return (_usersContext.USERS?.Any(user => user.Id == id)).GetValueOrDefault();
        }

        // Delete : api/User
        [HttpDelete("{id}")]
        public async Task<ActionResult<USERS>> DeleteUser(int id)
        {
            if (_usersContext.USERS is null)
            {
                return NotFound();
            }
            var uservar = await _usersContext.USERS.FindAsync(id);
            if (uservar is null)
            {
                return NotFound();
            }
            _usersContext.USERS.Remove(uservar);
            await _usersContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
