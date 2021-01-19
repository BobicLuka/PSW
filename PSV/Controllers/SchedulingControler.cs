using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    public class SchedulingControler : Controller
    {
        private object scheduling;

        public IActionResult Index()
        {
            return View();
        }

        [Route("/api/schedulings/{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            Scheduling scheduling;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    scheduling = unitOfWork.Schedulings.Get(id);
                }
            }
            catch (Exception e)
            {
                scheduling = null;
                return BadRequest(scheduling);
            }

            return Ok(scheduling);
        }

        private IActionResult BadRequest(object scheduling)
        {
            throw new NotImplementedException();
        }

        [Route("/api/schedulings")]
        [HttpPost]



        public async Task<IActionResult> Add(Scheduling scheduling)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    unitOfWork.Termins.Add(scheduling);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                scheduling = null;
                return BadRequest(scheduling);
            }

            return Ok(scheduling);
        }


    }
}
