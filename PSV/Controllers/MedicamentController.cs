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
    public class MedicamentControler : Controller
    {
        [Route("/api/medicaments/get-all")]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    return Ok(unitOfWork.Medicaments.GetAll());
                }
            }
            catch (Exception e)
            {

            }

            return BadRequest();
        }

        [Route("/api/medicaments/{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            Medicament medicament;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    medicament = unitOfWork.Medicaments.Get(id);
                }
            }
            catch (Exception e)
            {
                medicament = null;
                return BadRequest(medicament);
            }

            return Ok(medicament);
        }

        [Route("/api/medicaments")]
        [HttpPost]

        public async Task<IActionResult> Add(Medicament medicament)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ProjectContext()))
                {

                    unitOfWork.Medicaments.Add(medicament);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest(medicament);
            }

            return Ok(medicament);
        }
    }}