using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthyTeethAPI.Data;
using HealthyToothsModels;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsVisitsController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public ClientsVisitsController(HealphyTeethContext context)
        {
            _context = context;
        }

        // GET: api/ClientsVisits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientsVisit>>> GetClientsVisits()
        {
            return await _context.ClientsVisits.ToListAsync();
        }

        // GET: api/ClientsVisits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientsVisit>> GetClientsVisit(int id)
        {
            var clientsVisit = await _context.ClientsVisits.FindAsync(id);

            if (clientsVisit == null)
            {
                return NotFound();
            }

            return clientsVisit;
        }

        // PUT: api/ClientsVisits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientsVisit(int id, ClientsVisit clientsVisit)
        {
            if (id != clientsVisit.ClientVisitId)
            {
                return BadRequest();
            }

            _context.Entry(clientsVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsVisitExists(id))
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

        // POST: api/ClientsVisits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientsVisit>> PostClientsVisit(ClientsVisit clientsVisit)
        {
            _context.ClientsVisits.Add(clientsVisit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientsVisit", new { id = clientsVisit.ClientVisitId }, clientsVisit);
        }

        // DELETE: api/ClientsVisits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientsVisit(int id)
        {
            var clientsVisit = await _context.ClientsVisits.FindAsync(id);
            if (clientsVisit == null)
            {
                return NotFound();
            }

            _context.ClientsVisits.Remove(clientsVisit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientsVisitExists(int id)
        {
            return _context.ClientsVisits.Any(e => e.ClientVisitId == id);
        }
    }
}
