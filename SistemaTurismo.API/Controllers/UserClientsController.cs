using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.Modelos;

namespace SistemaTurismo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientsController : ControllerBase
    {
        private readonly DbContext _context;

        public UserClientsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/UsersClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClient>>> GetUserClient()
        {
            return await _context.UserClients.ToListAsync();
        }

        // GET: api/UsersClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserClient>> GetUserClient(int id)
        {
            var userClient = await _context.UserClients.FindAsync(id);

            if (userClient == null)
            {
                return NotFound();
            }

            return userClient;
        }

        // PUT: api/UsersClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserClient(int id, UserClient userClient)
        {
            if (id != userClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(userClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsersClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserClient>> PostUserClient(UserClient userClient)
        {
            _context.UserClients.Add(userClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserClient", new { id = userClient.Id }, userClient);
        }

        // DELETE: api/UsersClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserClient(int id)
        {
            var userClient = await _context.UserClients.FindAsync(id);
            if (userClient == null)
            {
                return NotFound();
            }

            _context.UserClients.Remove(userClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserClientExists(int id)
        {
            return _context.UserClients.Any(e => e.Id == id);
        }
    }
}
