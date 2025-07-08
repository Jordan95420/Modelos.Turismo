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
    public class UserAdminsController : ControllerBase
    {
        private readonly DbContext _context;

        public UserAdminsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/UserAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAdmin>>> GetUserAdmin()
        {
            return await _context.UserAdmins.ToListAsync();
        }

        // GET: api/UserAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAdmin>> GetUserAdmin(int id)
        {
            var userAdmin = await _context.UserAdmins.FindAsync(id);

            if (userAdmin == null)
            {
                return NotFound();
            }

            return userAdmin;
        }

        // PUT: api/UserAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAdmin(int id, UserAdmin userAdmin)
        {
            if (id != userAdmin.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAdminExists(id))
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

        // POST: api/UserAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAdmin>> PostUserAdmin(UserAdmin userAdmin)
        {
            _context.UserAdmins.Add(userAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAdmin", new { id = userAdmin.Id }, userAdmin);
        }

        // DELETE: api/UserAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAdmin(int id)
        {
            var userAdmin = await _context.UserAdmins.FindAsync(id);
            if (userAdmin == null)
            {
                return NotFound();
            }

            _context.UserAdmins.Remove(userAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAdminExists(int id)
        {
            return _context.UserAdmins.Any(e => e.Id == id);
        }
    }
}
