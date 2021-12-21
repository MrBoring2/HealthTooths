﻿using System;
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
    public class ClientsVisitsController : ControllerBase
    {
        private readonly IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;

        public ClientsVisitsController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
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
        [HttpPost("{storageId}")]
        public async Task<ActionResult<ClientsVisit>> PostClientsVisit([FromBody] ClientsVisit clientsVisit, int storageId)
        {

            var storage = _context.Storages.Include(p => p.ConsumablesInStorages).FirstOrDefault(p => p.StorageId == storageId);
            foreach (var item in clientsVisit.SpentConsumablesForVisits)
            {
                var consumable = storage.ConsumablesInStorages.FirstOrDefault(p => p.ConsumableId == item.СonsumableId);
                if (consumable == null)
                {
                    return BadRequest("Не хватает расходников на складе!");
                }
                else
                {
                    if (consumable.Amount - item.Amount <= 0)
                    {
                        return BadRequest("Не хватает расходников на складе!");
                    }
                    else
                    {
                        consumable.Amount -= item.Amount;
                    }
                }
            }

            var list = _context.Consumables.Include(p => p.ConsumableType).Include(p => p.ConsumablesInStorages).ToList();
            foreach (var item in list)
            {
                foreach (var storageItem in item.ConsumablesInStorages)
                {
                    _context.Entry(storageItem).Reference(p => p.Storage).Load();
                }
            }

            _context.Records.Remove(_context.Records.FirstOrDefault(p => p.ClientId == clientsVisit.ClientId && p.DoctorId == clientsVisit.DoctorId && p.RecordDate == clientsVisit.VisitDate));
            _context.ClientsVisits.Add(clientsVisit);

            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("UpdateRecored", JsonConvert.SerializeObject(_context.Records.Include(p=>p.Client), Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            await _hubContext.Clients.All.SendAsync("UpdateConsumables", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

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
