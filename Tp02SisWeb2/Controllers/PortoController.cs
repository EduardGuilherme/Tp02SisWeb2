using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp02SisWeb2.Controllers
{
    public class PortoController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Eae" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
