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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeeTimeCreate model)
        {

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