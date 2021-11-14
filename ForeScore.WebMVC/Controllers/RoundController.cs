using ForeScore.Models.HoleDataModels;
using ForeScore.Models.RoundModels;
using ForeScore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(model);
            }

            if (service.CreateRound(model))
            {
                TempData["SaveResult"] = "Round was successfully created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateRoundService();

            var model = service.GetRoundById(id);

            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRoundService();

            var entity = service.GetRoundById(id);

            var viewModel = new RoundEdit()
            {
                CourseDetail = entity.CourseDetail,
                CourseId = entity.CourseId,
                CourseName = entity.CourseName,
                DateOfRound = entity.DateOfRound,
                Description = entity.Description,
                IsFeatured = entity.IsFeatured,
                RoundId = entity.RoundId,
                IsPublic = entity.IsPublic,
                Score = entity.Score,
            };

            var _holes = new List<HoleDataEdit>();

            foreach(var hole in entity.FrontNine)
            {
                var holeData = new HoleDataEdit();

                holeData.DrivingDistance = hole.DrivingDistance;
                holeData.FairwayHit = hole.FairwayHit;
                holeData.HoleDataId = hole.HoleDataId;
                holeData.Penalty = hole.Penalty;
                holeData.Putts = hole.Putts;
                holeData.HoleNumber = hole.HoleNumber;
                holeData.Score = hole.Score;
                holeData.RoundId = hole.RoundId;

                _holes.Add(holeData);
            }

            var _holesBack = new List<HoleDataEdit>();

            foreach (var hole in entity.BackNine)
            {
                var holeData = new HoleDataEdit();

                holeData.DrivingDistance = hole.DrivingDistance;
                holeData.FairwayHit = hole.FairwayHit;
                holeData.HoleDataId = hole.HoleDataId;
                holeData.Penalty = hole.Penalty;
                holeData.Putts = hole.Putts;
                holeData.HoleNumber = hole.HoleNumber;
                holeData.Score = hole.Score;
                holeData.RoundId = hole.RoundId;

                _holesBack.Add(holeData);
            }

            var courseService = CreateCourseService();

            viewModel.FrontNine = _holes;
            viewModel.BackNine = _holesBack;
            viewModel.CourseDetail = courseService.GetCourseById(entity.CourseId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoundEdit model)
        {
            if (model.RoundId != id)
            {
                ModelState.AddModelError("", "Entered ID and the model ID do not match.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var service = CreateRoundService();
                service.EditRound(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateRoundService();

            var model = service.GetRoundById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRound(int id)
        {
            var service = CreateRoundService();

            if (service.RemoveRound(id))
            {
                TempData["SaveResult"] = "Round successfully deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Round could not be deleted");
            return View();
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