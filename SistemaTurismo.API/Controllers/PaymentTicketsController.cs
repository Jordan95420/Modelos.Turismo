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
    public class PaymentTicketsController : ControllerBase
    {
        private readonly DbContext _context;

        public PaymentTicketsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTicket>>> GetPaymentTicket()
        {
            return await _context.PaymentTickets.ToListAsync();
        }

        // GET: api/PaymentTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTicket>> GetPaymentTicket(int id)
        {
            var paymentTicket = await _context.PaymentTickets.FindAsync(id);

            if (paymentTicket == null)
            {
                return NotFound();
            }

            return paymentTicket;
        }

        // PUT: api/PaymentTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTicket(int id, PaymentTicket paymentTicket)
        {
            if (id != paymentTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTicketExists(id))
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

        // POST: api/PaymentTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTicket>> PostPaymentTicket(PaymentTicket paymentTicket)
        {
            _context.PaymentTickets.Add(paymentTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTicket", new { id = paymentTicket.Id }, paymentTicket);
        }

        // DELETE: api/PaymentTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTicket(int id)
        {
            var paymentTicket = await _context.PaymentTickets.FindAsync(id);
            if (paymentTicket == null)
            {
                return NotFound();
            }

            _context.PaymentTickets.Remove(paymentTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTicketExists(int id)
        {
            return _context.PaymentTickets.Any(e => e.Id == id);
        }
    }
}
