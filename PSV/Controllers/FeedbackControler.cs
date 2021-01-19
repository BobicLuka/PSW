using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    public class FeedbackControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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

    } 
}
