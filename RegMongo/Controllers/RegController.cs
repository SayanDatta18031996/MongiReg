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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AfterLogin(RegModel user)
        {
            return View(user);
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
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var user = await regService.Search(loginModel);
                if (user != null)
                {
                    if (user.Password == loginModel.Password)
                        return AfterLogin(user);
                }
                ViewBag.Message = "Name or password is wrong";
            }
            return View();
        }

    }
}
