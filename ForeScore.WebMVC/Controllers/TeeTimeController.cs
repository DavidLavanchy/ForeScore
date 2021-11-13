using ForeScore.Models.TeeTimeModels;
using ForeScore.Models.ViewModels;
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
    public class TeeTimeController : Controller
    {
        // GET: TeeTime
        public ActionResult Index()
        {
            var service = CreateTeeTimeService();

            var viewModel = new TeeTimeViewModel
            {
                RecentTeeTimes = service.RecentTeeTimes().ToList(),
                UpcomingTeeTimes = service.UpcomingTeeTimes().ToList(),
            };

            return View(viewModel);
        }

        public ActionResult SelectCourse()
        {
            var crsService = CreateCourseService();

            var viewModel = crsService.GetAllCourses();

            return View(viewModel);
        }

        public ActionResult Create(int id)
        {
            var crsService = CreateCourseService();
            var course = crsService.GetCourseById(id);

            var viewModel = new TeeTimeCreate
            {
                CourseId = id,
                CourseName = course.Name,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeeTimeCreate model)
        {
            var service = CreateTeeTimeService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreateTeeTime(model))
            {
                TempData["SaveResult"] = "TeeTime was successfully created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var teeTimeService = CreateTeeTimeService();

            var viewModel = teeTimeService.GetTeeTimeById(id);

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var teeTimeService = CreateTeeTimeService();

            var viewModel = teeTimeService.GetTeeTimeById(id);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeeTime(int id)
        {
            var teeTimeService = CreateTeeTimeService();

            if (teeTimeService.DeleteTeeTime(id))
            {
                TempData["SaveResult"] = "TeeTime was successfully deleted.";
                return RedirectToAction("Index");
            }

            return View();
        }

        private TeeTimeServices CreateTeeTimeService()
        {
            var userId = User.Identity.GetUserId();
            var service = new TeeTimeServices(userId);
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