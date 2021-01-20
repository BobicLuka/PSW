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
    public class FeedbackControler : Controller
    {
        [Route("/api/feedbacks/{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            Feedback feedback;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    feedback = unitOfWork.Feedbacks.Get(id);
                }
            }
            catch (Exception e)
            {
                feedback = null;
                return BadRequest(feedback);
            }

            return Ok(feedback);
        }

        [Route("/api/feedbacks")]
        [HttpPost]

        public async Task<IActionResult> Add(Feedback feedback)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    unitOfWork.Feedbacks.Add(feedback);
                    feedback.Kom = false;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                feedback = null;
                return BadRequest(feedback);
            }

            return Ok(feedback);
        }

        [Route("/api/feedbacks/all")]
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    return Ok(unitOfWork.Feedbacks.GetAll());
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [Route("/api/feedbacks/publish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Block(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    Feedback feedback = unitOfWork.Feedbacks.Get(id);

                    if (feedback == null)
                    {
                        return BadRequest();
                    }

                    feedback.Kom = true;
                    unitOfWork.Context.Set<Feedback>().Attach(feedback);
                    unitOfWork.Context.Entry(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [Route("/api/feedbacks/unpublish/{id}")]
        [HttpPost]
        public async Task<IActionResult> Unblock(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    Feedback feedback = unitOfWork.Feedbacks.Get(id);

                    if (feedback == null)
                    {
                        return BadRequest();
                    }

                    feedback.Kom = false;
                    unitOfWork.Context.Set<Feedback>().Attach(feedback);
                    unitOfWork.Context.Entry(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
