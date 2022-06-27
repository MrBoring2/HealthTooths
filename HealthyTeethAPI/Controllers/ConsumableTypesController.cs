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
    public class ConsumableTypesController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public ConsumableTypesController(HealphyTeethContext context)
        {
            _context = context;
        }

        // GET: api/ConsumableTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumableType>>> GetConsumableTypes()
        {
            return await _context.ConsumableTypes.ToListAsync();
        }

        // GET: api/ConsumableTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableType>> GetConsumableType(int id)
        {
            var consumableType = await _context.ConsumableTypes.FindAsync(id);

            if (consumableType == null)
            {
                return NotFound();
            }

            return consumableType;
        }

        // PUT: api/ConsumableTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumableType(int id, ConsumableType consumableType)
        {
            if (id != consumableType.ConsumableTypeId)
            {
                return BadRequest();
            }

            _context.Entry(consumableType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumableTypeExists(id))
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

        // POST: api/ConsumableTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsumableType>> PostConsumableType(ConsumableType consumableType)
        {
            _context.ConsumableTypes.Add(consumableType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumableType", new { id = consumableType.ConsumableTypeId }, consumableType);
        }

        // DELETE: api/ConsumableTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumableType(int id)
        {
            var consumableType = await _context.ConsumableTypes.FindAsync(id);
            if (consumableType == null)
            {
                return NotFound();
            }

            _context.ConsumableTypes.Remove(consumableType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumableTypeExists(int id)
        {
            return _context.ConsumableTypes.Any(e => e.ConsumableTypeId == id);
        }
    }
}
