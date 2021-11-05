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
            var viewModel = service.GetAllRoundsByUserId();
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var service = CreateCourseService();

            var viewModel = service.GetAllCourses();

            return View(viewModel);

        }

        public ActionResult SelectCourse(int id)
        {
            var service = CreateRoundService();
            var courseService = CreateCourseService();

            var viewModel = service.NullRound();

            viewModel.CourseDetail = courseService.GetCourseById(id);

            viewModel.CourseId = viewModel.CourseDetail.CourseId;

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectCourse(RoundCreateModel model)
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

        private CourseServices CreateCourseService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CourseServices(userId);
            return service;
        }

    }
}