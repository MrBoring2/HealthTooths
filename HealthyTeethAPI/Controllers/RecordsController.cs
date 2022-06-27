using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthyTeethAPI.Data;
using Microsoft.AspNetCore.SignalR;
using HealthyTeethAPI.Hubs;
using Newtonsoft.Json;
using HealthyToothsModels;
using Microsoft.AspNetCore.Authorization;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecordsController : ControllerBase
    {
        private IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;

        public RecordsController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        /// <summary>
        /// GET запрос на получение всех записей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        /// <summary>
        /// GET запрос на получение всех записей отпределённого доктора
        /// </summary>
        /// <returns></returns>
        [HttpGet("getForDoctor")]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords(int doctorId)
        {
            return await _context.Records.Include(p => p.Client).Where(p => p.DoctorId == doctorId).ToListAsync();
        }

        /// <summary>
        /// GET запрос на получение определённого записи
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            var @record = await _context.Records.FindAsync(id);

            if (@record == null)
            {
                return NotFound();
            }

            return @record;
        }

        /// <summary>
        /// PUT запрос на редактирование записи
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, Record @record)
        {
            if (id != @record.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(@record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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
        /// POST запрос на добавление записи
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(Record @record)
        {
            record.RecordDate = DateTime.Parse(@record.DateString);
            var records = _context.Records.Where(p => p.DoctorId == record.DoctorId).ToList();
            if (records.FirstOrDefault(p => p.RecordDate == @record.RecordDate) != null)
            {
                return BadRequest($"У доктора уже запись на {records.FirstOrDefault(p => p.RecordDate == @record.RecordDate).RecordDate}. Новая запись должна быть только через 30 минут.");
            }
            
            _context.Records.Add(@record);
            await _context.SaveChangesAsync();
            var connectionId = "";
            if (MainHub.ConnectedUsers.TryGetValue(_context.Employees.FirstOrDefault(p => p.EmployeeId == @record.DoctorId).Login, out connectionId))
            {
                var list = await _context.Records.Include(p => p.Client).Where(p => p.DoctorId == record.DoctorId).Include(p => p.Client).ToListAsync();
                await _hubContext.Clients.Client(connectionId).SendAsync("UpdateRecords", JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            return CreatedAtAction("GetRecord", new { id = @record.RecordId }, @record);
        }

        /// <summary>
        /// DELETE запрос на удаление записи
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var @record = await _context.Records.FindAsync(id);
            if (@record == null)
            {
                return NotFound();
            }
            var connectionId = "";
            MainHub.ConnectedUsers.TryGetValue(HttpContext.User.Identity.Name, out connectionId);
            _context.Records.Remove(@record);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.Client(connectionId).SendAsync("UpdateRecords", JsonConvert.SerializeObject(_context.Records.Include(p => p.Client).Include(p => p.Doctor).Where(p => p.DoctorId == record.DoctorId), Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok();
        }

        /// <summary>
        /// Проверка, если ли данная запись в базе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.RecordId == id);
        }
    }
}
