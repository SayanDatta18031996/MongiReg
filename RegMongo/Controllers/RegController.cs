using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegMongo.Models;
using RegMongo.Service;

namespace RegMongo.Controllers
{
    public class RegController : Controller
    {
        private readonly RegService regService;
        public RegController(RegService regService)
        {
            this.regService = regService;
        }
        public IActionResult Index()
        {
            return View(regService.Get());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegModel regModel)
        {
            if (ModelState.IsValid)
            {
                regService.Create(regModel);
                return RedirectToAction(nameof(Index));
            }
            return View(regModel);

        }
    }
}
