using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    public class SchedulingControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
