using HealthyTeethAPI.Data;
using HealthyTeethAPI.Helpers;
using HealthyTeethAPI.Hubs;
using HealthyTeethAPI.Models;
using HealthyToothsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthyTeethAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IHubContext<MainHub> _hubContext;
        private readonly HealphyTeethContext _context;
        public AuthenticateController(HealphyTeethContext context, IHubContext<MainHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        // GET: api/<AuthenticateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
                {
                    return BadRequest("Поля не должны быть пустыми!");
                }

                if (MainHub.ConnectedUsers.TryGetValue(model.Login, out string connectionId))
                {
                    if (connectionId != null)
                    {
                        return BadRequest("Пользователь уже авторизирован!");
                    }
                }
                var identity = GetIdentity(model);

                if (identity.Result == null)
                {
                    return BadRequest("Неверное имя пользователя или пароль");
                }

                var token = CreateToken(identity.Result);
                return Ok(token);
            }
            else return BadRequest();
        }
        private dynamic CreateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //HttpContext.Session.SetString("JWToken", encodedJwt);
            var response = new
            {
                access_token = encodedJwt,
                user_name = identity.FindFirst(ClaimsIdentity.DefaultNameClaimType).Value.ToString(),
                full_name = identity.FindFirst("full_name")?.Value.ToString(),
                role_name = identity.FindFirst(ClaimsIdentity.DefaultRoleClaimType).Value.ToString(),
                user_id = identity.FindFirst("user_id")?.Value.ToString(),
                role_id = identity.FindFirst("role_id")?.Value.ToString()
            };

            return response;
        }

        private async Task<ClaimsIdentity> GetIdentity(LoginModel model)
        {
            Employee user = await _context.Employees.Include(r => r.Role)
                .FirstOrDefaultAsync(x => x.Login == model.Login && x.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("user_id", user.EmployeeId.ToString()),
                    new Claim("full_name", user.FullName.ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim("role_id", user.Role.RoleId.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
