using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RecepieService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepieService.Controllers
{

    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class RecepieController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Recepie> Get()
        {
            return Singlton.Instance.Recepies;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Recepie recepie)
        {
            Singlton.Instance.Recepies.Add(recepie);

            return Ok();
        }

    }
}
