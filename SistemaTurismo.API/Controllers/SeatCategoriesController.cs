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
    public class SeatCategoriesController : ControllerBase
    {
        private readonly DbContext _context;

        public SeatCategoriesController(DbContext context)
        {
            _context = context;
        }

        // GET: api/SeatCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatCategory>>> GetSeatCategory()
        {
            return await _context.SeatCategories.ToListAsync();
        }

        // GET: api/SeatCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatCategory>> GetSeatCategory(int id)
        {
            var seatCategory = await _context.SeatCategories.FindAsync(id);

            if (seatCategory == null)
            {
                return NotFound();
            }

            return seatCategory;
        }

        // PUT: api/SeatCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatCategory(int id, SeatCategory seatCategory)
        {
            if (id != seatCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatCategoryExists(id))
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

        // POST: api/SeatCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatCategory>> PostSeatCategory(SeatCategory seatCategory)
        {
            _context.SeatCategories.Add(seatCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatCategory", new { id = seatCategory.Id }, seatCategory);
        }

        // DELETE: api/SeatCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatCategory(int id)
        {
            var seatCategory = await _context.SeatCategories.FindAsync(id);
            if (seatCategory == null)
            {
                return NotFound();
            }

            _context.SeatCategories.Remove(seatCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatCategoryExists(int id)
        {
            return _context.SeatCategories.Any(e => e.Id == id);
        }
    }
}
