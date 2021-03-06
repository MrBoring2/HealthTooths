using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthyTeethAPI.Data;
using HealthyToothsModels;
using Microsoft.AspNetCore.Authorization;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CabinetsController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public CabinetsController(HealphyTeethContext context)
        {
            _context = context;
        }

        // GET: api/Cabinets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cabinet>>> GetCabinets()
        {
            return await _context.Cabinets.ToListAsync();
        }

        // GET: api/Cabinets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cabinet>> GetCabinet(int id)
        {
            var cabinet = await _context.Cabinets.FindAsync(id);

            if (cabinet == null)
            {
                return NotFound();
            }

            return cabinet;
        }

        // PUT: api/Cabinets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabinet(int id, Cabinet cabinet)
        {
            if (id != cabinet.CabinetId)
            {
                return BadRequest();
            }

            _context.Entry(cabinet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinetExists(id))
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

        // POST: api/Cabinets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cabinet>> PostCabinet(Cabinet cabinet)
        {
            _context.Cabinets.Add(cabinet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabinet", new { id = cabinet.CabinetId }, cabinet);
        }

        // DELETE: api/Cabinets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabinet(int id)
        {
            var cabinet = await _context.Cabinets.FindAsync(id);
            if (cabinet == null)
            {
                return NotFound();
            }

            _context.Cabinets.Remove(cabinet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CabinetExists(int id)
        {
            return _context.Cabinets.Any(e => e.CabinetId == id);
        }
    }
}
