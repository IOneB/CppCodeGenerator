using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly GeneratorService _service;

        public HomeController(GeneratorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Generate(Class @class)
        {
            if (!ModelState.IsValid)
                return Content("Недостаточно данных!");

            return Content(_service.Generate(@class));
        }
    }
}
