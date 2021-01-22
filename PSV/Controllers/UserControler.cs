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
        [Route("/api/users/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    return Ok(unitOfWork.Users.GetAll());
                }
            }
            catch(Exception e)
            {
                BadRequest();
            }

            return Ok();
        }

        [Route("/api/users/doctors")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    return Ok(unitOfWork.Users.GetAllDoctors());
                }
            }
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }

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

        [Route("/api/users/block/{id}")]
        [HttpPost]
        public async Task<IActionResult> Block(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    User user = unitOfWork.Users.Get(id);

                    if (user == null) {
                        return BadRequest();
                    }

                    user.Blocked = true;
                    unitOfWork.Context.Set<User>().Attach(user);
                    unitOfWork.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [Route("/api/users/unblock/{id}")]
        [HttpPost]
        public async Task<IActionResult> Unblock(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    User user = unitOfWork.Users.Get(id);

                    if (user == null)
                    {
                        return BadRequest();
                    }

                    user.Blocked = false;
                    unitOfWork.Context.Set<User>().Attach(user);
                    unitOfWork.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        
    }
}
