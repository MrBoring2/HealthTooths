using HealthyTeethAPI.Data;
using HealthyTeethAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly HealphyTeethContext _context;

        public AuthenticationController(HealphyTeethContext context)
        {
            _context = context;
        }
        // POST api/<AuthenticationController>
        [HttpPost("loginClient")]
        public async Task<ActionResult<Client>> PostLoginClient([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var client = await _context.Clients.FirstOrDefaultAsync(p => p.ClientLogin.Equals(loginModel.Password) && p.ClientPassword.Equals(loginModel.Password));
                if (client != null)
                {
                    return client;
                }
                else
                {
                    ModelState.AddModelError("Error", "Неверный логин или пароль!");
                    return BadRequest();
                }
            }
            else
            {
                ModelState.AddModelError("ValidateError", "Неккоректно введены данные!");
                return BadRequest();
            }

        }

        [HttpPost("loginEmployee")]
        public async Task<ActionResult<Employee>> PostLoginEmployee([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.Include(p => p.Role).FirstOrDefaultAsync(p => p.Login.Equals(loginModel.Login) && p.Password.Equals(loginModel.Password));
                if (employee != null)
                {
                    if (employee is Doctor d)
                    {
                        _context.Entry(d).Collection(p => p.Records).Load();
                        _context.Entry(d).Reference(p => p.Cabinet).Load();
                    }

                    return Ok(employee);
                }
                else
                {
                    ModelState.AddModelError("Error", "Неверный логин или пароль!");
                    return BadRequest(ModelState.Values.SelectMany(p => p.Errors));
                }
            }
            else
            {
                ModelState.AddModelError("ValidateError", "Неккоректно введены данные!");
                return BadRequest(ModelState.Values.SelectMany(p => p.Errors));
            }
        }

        [HttpPost("registerClient")]
        public void PostRegisterClient([FromBody] Client client)
        {
        }
        [HttpPost("registerEmployee")]
        public void PostRegisterEmployee([FromBody] Employee employee)
        {
        }

    }
}
