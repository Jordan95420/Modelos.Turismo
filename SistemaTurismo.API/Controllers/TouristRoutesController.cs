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
    public class TouristRoutesController : ControllerBase
    {
        private readonly DbContext _context;

        public TouristRoutesController(DbContext context)
        {
            _context = context;
        }

        // GET: api/TouristRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TouristRoute>>> GetTouristRoute()
        {
            return await _context.TouristRoutes.ToListAsync();
        }

        // GET: api/TouristRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristRoute>> GetTouristRoute(int id)
        {
            var touristRoute = await _context.TouristRoutes.FindAsync(id);

            if (touristRoute == null)
            {
                return NotFound();
            }

            return touristRoute;
        }

        // PUT: api/TouristRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTouristRoute(int id, TouristRoute touristRoute)
        {
            if (id != touristRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(touristRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristRouteExists(id))
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

        // POST: api/TouristRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TouristRoute>> PostTouristRoute(TouristRoute touristRoute)
        {
            _context.TouristRoutes.Add(touristRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTouristRoute", new { id = touristRoute.Id }, touristRoute);
        }

        // DELETE: api/TouristRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTouristRoute(int id)
        {
            var touristRoute = await _context.TouristRoutes.FindAsync(id);
            if (touristRoute == null)
            {
                return NotFound();
            }

            _context.TouristRoutes.Remove(touristRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TouristRouteExists(int id)
        {
            return _context.TouristRoutes.Any(e => e.Id == id);
        }
    }
}
