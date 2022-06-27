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
using HealthyTeethAPI.Helpers;

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;

        public EmployeesController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        /// <summary>
        /// GET запрос на получение всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(p => p.Role).ToListAsync();
            foreach (var employee in employees)
            {
                if (employee is Doctor d)
                {
                    _context.Entry(d).Collection(p => p.Records).Load();
                    _context.Entry(d).Reference(p => p.Cabinet).Load();
                }
            }
            return employees;
        }

        /// <summary>
        /// GET запрос на получение определённого сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        /// <summary>
        /// PUT запрос на редактирование сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            if (employee is Doctor d)
            {
                var doctor = _context.Doctors.Find(id);
                //_context.Entry(doctor).Reference(p => p.Role).Load();

                //if (doctor.Role.RoleId != employee.Role.RoleId)
                //{
                //    _context.Doctors.Remove(doctor);
                //    if (employee.Role.RoleId == 3)
                //    {
                //        _context.Administrators.Add(new Administrator
                //        { 
                //            DateOfBirth =  employee.DateOfBirth,
                //            });
                //    }
                //}

                doctor.DateOfBirth = d.DateOfBirth;
                doctor.FullName = d.FullName;
                doctor.Gender = d.Gender;
                doctor.Password = d.Password;
                doctor.PassportNumber = d.PassportNumber;
                doctor.PassportSeries = d.PassportSeries;
                doctor.PhoneNumber = d.PhoneNumber;
                doctor.Login = d.Login;
                //doctor.Role.RoleId = d.Role.RoleId;
                doctor.CabinetId = d.CabinetId;
                _context.Entry(doctor).State = EntityState.Modified;
            }
            else if (employee is Administrator a)
            {
                var administrator = _context.Administrators.Find(id);
                administrator.DateOfBirth = a.DateOfBirth;
                administrator.FullName = a.FullName;
                administrator.Gender = a.Gender;
                administrator.Password = a.Password;
                administrator.Login = a.Login;
                administrator.PassportNumber = a.PassportNumber;
                administrator.PassportSeries = a.PassportSeries;
                administrator.PhoneNumber = a.PhoneNumber;
                _context.Entry(administrator).State = EntityState.Modified;
            }

            try
            {

                await _context.SaveChangesAsync();
                var employees = _context.Employees.Include(p => p.Role).ToList();
                employees = IncludeReferencesEmployees(employees).ToList();
                await _hubContext.Clients.Group(SignalRGroups.admins_group).SendAsync("UpdateEmployees", JsonConvert.SerializeObject(employees, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
                }));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
        /// POST запрос на добавление сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (employee is Doctor d)
            {
                _context.Doctors.Add(d);
            }
            else if (employee is Administrator a)
            {
                _context.Administrators.Add(a);
            }
            await _context.SaveChangesAsync();
            var employees = _context.Employees.Include(p => p.Role).ToList();
            employees = IncludeReferencesEmployees(employees).ToList();
            await _hubContext.Clients.All.SendAsync("UpdateEmployees", JsonConvert.SerializeObject(employees, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
            }));

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        /// <summary>
        /// DELETE запрос на удаление сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            var employees = _context.Employees.Include(p => p.Role).ToList();
            employees = IncludeReferencesEmployees(employees).ToList();
            await _hubContext.Clients.All.SendAsync("UpdateEmployees", JsonConvert.SerializeObject(employees, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
            }));

            return Ok();
        }

        /// <summary>
        /// Проверка, если ли данный сотрудник в базе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        private IEnumerable<Employee> IncludeReferencesEmployees(IEnumerable<Employee> employees)
        {
            foreach (var item in employees)
            {
                if (item is Doctor d)
                {
                    _context.Entry(d).Reference(p => p.Cabinet).Load();
                }
            }
            return employees;
        }
    }
}
