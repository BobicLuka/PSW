using Microsoft.AspNetCore.Mvc;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    public class TerminControlor : Controller
    {
        private object termin;

        public IActionResult Index()
        {
            return View();
        }



        [Route("/api/feedbacks/{id}")]
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
        [HttpPost]


        public async Task<IActionResult> Add(Termin termin)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

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

    }
}
