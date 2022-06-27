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
using Microsoft.AspNetCore.Authorization;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveriesController : ControllerBase
    {
        private IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;

        public DeliveriesController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // PUT: api/Deliveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);

            var storage = _context.Storages.Include(p => p.ConsumablesInStorages).FirstOrDefault(p => p.StorageId == delivery.StorageId);

            foreach (var item in delivery.ConsumablesInDeliveries)
            {
                var consumable = storage.ConsumablesInStorages.FirstOrDefault(p => p.ConsumableId == item.ConsumableId);
                if (consumable == null)
                {
                    _context.ConsumablesInStorages.Add(new ConsumablesInStorage { ConsumableId = item.ConsumableId, Amount = item.Amount, StorageId = delivery.StorageId });
                }
                else
                {
                    consumable.Amount += item.Amount;
                }
            }

            await _context.SaveChangesAsync();
            var list = _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages);
            foreach (var item in list)
            {
                foreach (var storageItem in item.ConsumablesInStorages)
                {
                    _context.Entry(storageItem).Reference(p => p.Storage).Load();
                }
            }
            await _hubContext.Clients.All.SendAsync("UpdateConsumables", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            return CreatedAtAction("GetDelivery", new { id = delivery.DeliveryId }, delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryExists(int id)
        {
            return _context.Deliveries.Any(e => e.DeliveryId == id);
        }
    }
}
