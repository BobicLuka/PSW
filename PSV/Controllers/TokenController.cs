using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IConfiguration configuration;


        public TokenController(IConfiguration config)

        {
            configuration = config;
        }

        [HttpPost]
        public async Task<ActionResult> Post(User userData)

        {
            if (userData == null || userData.Email == null || userData.Password == null)
            {
                return BadRequest("Invalid credentials");
            }

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {
                    user = unitOfWork.Users.GetUserWithEmailAndPassword(userData.Email, userData.Password);
                }

            }
            catch (Exception e) { }

            if (user == null)
            {
                return BadRequest();
            }

            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub , configuration ["Jwt:Subject"]),
                new Claim (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                new Claim ("Id",User.Identity.ToString()),
                new Claim ("FirstName", user.FirstName),
                new Claim ("LastName", user.LastName),
                new Claim ("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [Route("/api/token/get-current")]
        [HttpGet]
        public async Task<ActionResult> GetCurrentUser()
        {
            string email = HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Email")?.Value;

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {
                    user = unitOfWork.Users.GetUserWithEmail(email);
                }
            }
            catch (Exception e)
            {

            }

            return Ok(user);
        }

    }
}

