using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : Controller
    {
        [Route("/api/users/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            User user;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext())) {

                    user = unitOfWork.Users.Get(id);
                }
            }
            catch (Exception e) 
            {
                user = null;
                return BadRequest(user);
            }

            return Ok(user);
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    unitOfWork.Users.Add(user);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                user = null;
                return BadRequest(user);
            }

            return Ok(user);
        }
    }
}
