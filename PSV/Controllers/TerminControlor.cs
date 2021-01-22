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
    public class TerminControlor : Controller
    {

        [Route("/api/termins/{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            Termin termin;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    termin = unitOfWork.Termins.Get(id);
                }
            }
            catch (Exception e)
            {
                termin = null;
                return BadRequest(termin);
            }

            return Ok(termin);
        }

        [Route("/api/termins")]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    return Ok(unitOfWork.Termins.GetAll());
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("/api/termins")]
        [HttpPost]
        public async Task<IActionResult> Add(Termin termin)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {
                    User user = unitOfWork.Users.Get(termin.Doctor.Id);
                    termin.Doctor = user;
                    termin.IsFree = true;
                    unitOfWork.Termins.Add(termin);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                termin = null;
                return BadRequest(termin);
            }

            return Ok(termin);
        }

        [Route("/api/termins/take/{id}")]
        [HttpPost]
        public async Task<IActionResult> Take(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {
                    Termin termin = unitOfWork.Termins.Get(id);
                    termin.IsFree = false;
                    termin.Patient = GetCurrentUser();
                    unitOfWork.Context.Attach(termin);
                    unitOfWork.Context.Entry(termin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("/api/termins/free/{id}")]
        [HttpPost]
        public async Task<IActionResult> Free(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {
                    Termin termin = unitOfWork.Termins.Get(id);
                    termin.IsFree = true;
                    termin.Patient = GetCurrentUser();
                    unitOfWork.Context.Attach(termin);
                    unitOfWork.Context.Entry(termin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        private User GetCurrentUser()
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

            return user;
        }
    }
}

