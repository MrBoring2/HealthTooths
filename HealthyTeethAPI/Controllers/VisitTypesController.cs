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
    public class VisitTypesController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public VisitTypesController(HealphyTeethContext context)
        {
            _context = context;
        }

        // GET: api/VisitTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitType>>> GetVisitTypes()
        {
            return await _context.VisitTypes.ToListAsync();
        }

        // GET: api/VisitTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitType>> GetVisitType(int id)
        {
            var visitType = await _context.VisitTypes.FindAsync(id);

            if (visitType == null)
            {
                return NotFound();
            }

            return visitType;
        }

        // PUT: api/VisitTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitType(int id, VisitType visitType)
        {
            if (id != visitType.VisitTypeId)
            {
                return BadRequest();
            }

            _context.Entry(visitType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitTypeExists(id))
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

        // POST: api/VisitTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitType>> PostVisitType(VisitType visitType)
        {
            _context.VisitTypes.Add(visitType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitType", new { id = visitType.VisitTypeId }, visitType);
        }

        // DELETE: api/VisitTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitType(int id)
        {
            var visitType = await _context.VisitTypes.FindAsync(id);
            if (visitType == null)
            {
                return NotFound();
            }

            _context.VisitTypes.Remove(visitType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitTypeExists(int id)
        {
            return _context.VisitTypes.Any(e => e.VisitTypeId == id);
        }
    }
}
