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
    public class ConsumablesController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public ConsumablesController(HealphyTeethContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET запрос на получение всех расходников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumable>>> GetConsumables()
        {
            return await _context.Consumables.Include(p=>p.ConsumableType).Include(p=>p.ConsumablesInStorages).ToListAsync();
           
        }

        /// <summary>
        /// GET запрос на получение определённого расходника
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumable>> GetConsumable(int id)
        {
            var consumable = await _context.Consumables.FindAsync(id);

            if (consumable == null)
            {
                return NotFound();
            }

            return consumable;
        }

        /// <summary>
        /// PUT запрос на редактирование расходника
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumable(int id, Consumable consumable)
        {
            if (id != consumable.ConsumableId)
            {
                return BadRequest();
            }

            _context.Entry(consumable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumableExists(id))
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

        /// <summary>
        /// POST запрос на добавление расходника
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Consumable>> PostConsumable(Consumable consumable)
        {
            _context.Consumables.Add(consumable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumable", new { id = consumable.ConsumableId }, consumable);
        }

        /// <summary>
        /// DELETE запрос на удаление расходника
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumable(int id)
        {
            var consumable = await _context.Consumables.FindAsync(id);
            if (consumable == null)
            {
                return NotFound();
            }

            _context.Consumables.Remove(consumable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Проверка, если ли данный расходник в базе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ConsumableExists(int id)
        {
            return _context.Consumables.Any(e => e.ConsumableId == id);
        }
    }
}
