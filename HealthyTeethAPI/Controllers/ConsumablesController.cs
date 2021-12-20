using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthyTeethAPI.Data;
using HealthyToothsModels;
using Microsoft.AspNetCore.SignalR;
using HealthyTeethAPI.Hubs;
using Newtonsoft.Json;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablesController : ControllerBase
    {
        private IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;

        public ConsumablesController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        /// <summary>
        /// GET запрос на получение всех расходников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumable>>> GetConsumables()
        {
            var list = await _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages).ToListAsync();
            foreach (var item in list)
            {
                foreach (var storage in item.ConsumablesInStorages)
                {

                    _context.Entry(storage).Reference(p => p.Storage).Load();
                }
            }
            return list;
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
                var list = await _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages).ToListAsync();
                foreach (var item in list)
                {
                    foreach (var storage in item.ConsumablesInStorages)
                    {

                        _context.Entry(storage).Reference(p => p.Storage).Load();
                    }
                }
                await _hubContext.Clients.All.SendAsync("UpdateConsumables", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

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

            return Ok();
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
            var list = await _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages).ToListAsync();
            foreach (var item in list)
            {
                foreach (var storage in item.ConsumablesInStorages)
                {

                    _context.Entry(storage).Reference(p => p.Storage).Load();
                }
            }
            await _hubContext.Clients.All.SendAsync("UpdateConsumables", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

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
            var list = await _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages).ToListAsync();
            foreach (var item in list)
            {
                foreach (var storage in item.ConsumablesInStorages)
                {

                    _context.Entry(storage).Reference(p => p.Storage).Load();
                }
            }
            await _hubContext.Clients.All.SendAsync("UpdateConsumables", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            return Ok();
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
