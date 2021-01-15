using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    public class TerminControlor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
