using HealthyToothsModels;
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
        
        /// <summary>
        /// POST запрос для авторизации сотрудников
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost("loginEmployee")]
        public async Task<ActionResult<Employee>> PostLoginEmployee([FromBody] LoginModel loginModel)
        {
            //Если нет ошибок в модели
            if (ModelState.IsValid)
            {
                //Ищем сотрудника с данным логином и паролем
                var employee = await _context.Employees.Include(p => p.Role).FirstOrDefaultAsync(p => p.Login.Equals(loginModel.Login) && p.Password.Equals(loginModel.Password));
                if (employee != null)
                {
                    //Если нашли, то подгружаем нужные ему поля и отправляем на приложение
                    if (employee is Doctor d)
                    {
                        _context.Entry(d).Collection(p => p.Records).Load();
                        _context.Entry(d).Reference(p => p.Cabinet).Load();
                    }

                    return Ok(employee);
                }
                else
                {
                    //Иначе отправляем ошибка
                    ModelState.AddModelError("Error", "Неверный логин или пароль!");
                    return BadRequest(ModelState.Values.SelectMany(p => p.Errors));
                }
            }
            else
            {
                //Иначе отправляем ошибка
                ModelState.AddModelError("ValidateError", "Неккоректно введены данные!");
                return BadRequest(ModelState.Values.SelectMany(p => p.Errors));
            }
        }

        [HttpPost("registerEmployee")]
        public void PostRegisterEmployee([FromBody] Employee employee)
        {
        }

    }
}
