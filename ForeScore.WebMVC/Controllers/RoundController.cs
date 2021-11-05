using ForeScore.Models.RoundModels;
using ForeScore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForeScore.WebMVC.Controllers
{
    [Authorize]
    public class RoundController : Controller
    {
        // GET: Round
        public ActionResult Index()
        {
            var service = CreateRoundService();
            service.GetAllRoundsByUserId();
            return View(service);
        }

        public ActionResult Create()
        {
            var service = CreateRoundService();

            var viewModel = service.NullRound();

            viewModel.Courses = service.Courses();

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoundCreateModel model)
        {
            var service = CreateRoundService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateRound(model))
            {
                TempData["SaveResult"] = "Round was successfully created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private RoundServices CreateRoundService()
        {
            var userId = User.Identity.GetUserId();
            var service = new RoundServices(userId);

            return service;
        }

    }
}