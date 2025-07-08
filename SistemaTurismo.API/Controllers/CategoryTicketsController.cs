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
    public class CategoryTicketsController : ControllerBase
    {
        private readonly DbContext _context;

        public CategoryTicketsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTicket>>> GetCategoryTicket()
        {
            return await _context.CategoryTickets.ToListAsync();
        }

        // GET: api/CategoryTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryTicket>> GetCategoryTicket(int id)
        {
            var categoryTicket = await _context.CategoryTickets.FindAsync(id);

            if (categoryTicket == null)
            {
                return NotFound();
            }

            return categoryTicket;
        }

        // PUT: api/CategoryTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryTicket(int id, CategoryTicket categoryTicket)
        {
            if (id != categoryTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTicketExists(id))
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

        // POST: api/CategoryTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryTicket>> PostCategoryTicket(CategoryTicket categoryTicket)
        {
            _context.CategoryTickets.Add(categoryTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryTicket", new { id = categoryTicket.Id }, categoryTicket);
        }

        // DELETE: api/CategoryTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryTicket(int id)
        {
            var categoryTicket = await _context.CategoryTickets.FindAsync(id);
            if (categoryTicket == null)
            {
                return NotFound();
            }

            _context.CategoryTickets.Remove(categoryTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryTicketExists(int id)
        {
            return _context.CategoryTickets.Any(e => e.Id == id);
        }
    }
}
