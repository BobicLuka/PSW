using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PSV.Controllers
{
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

                }

            }
            catch (Exception e) { }


            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub , configuration ["Jwt:Subject"]),
                new Claim (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                new Claim ("Id",User.Identity.ToString()),
                new Claim ("FirstName", user.FirstName),
                new Claim ("LastName", user.LastName),
                new Claim ("Email", User.Email)
            };

            var key = new SymetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmaxSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }

        private async Task GetUser(string email, string password)

        {


        
                
            }
        }

    }


