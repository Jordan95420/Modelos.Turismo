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
    public class TouristsTicketsController : ControllerBase
    {
        private readonly DbContext _context;

        public TouristsTicketsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/TouristsTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TouristTicket>>> GetTouristTicket()
        {
            return await _context.TouristTickets.ToListAsync();
        }

        // GET: api/TouristsTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristTicket>> GetTouristTicket(int id)
        {
            var touristTicket = await _context.TouristTickets.FindAsync(id);

            if (touristTicket == null)
            {
                return NotFound();
            }

            return touristTicket;
        }

        // PUT: api/TouristsTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTouristTicket(int id, TouristTicket touristTicket)
        {
            if (id != touristTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(touristTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristTicketExists(id))
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

        // POST: api/TouristsTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TouristTicket>> PostTouristTicket(TouristTicket touristTicket)
        {
            _context.TouristTickets.Add(touristTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTouristTicket", new { id = touristTicket.Id }, touristTicket);
        }

        // DELETE: api/TouristsTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTouristTicket(int id)
        {
            var touristTicket = await _context.TouristTickets.FindAsync(id);
            if (touristTicket == null)
            {
                return NotFound();
            }

            _context.TouristTickets.Remove(touristTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TouristTicketExists(int id)
        {
            return _context.TouristTickets.Any(e => e.Id == id);
        }
    }
}
