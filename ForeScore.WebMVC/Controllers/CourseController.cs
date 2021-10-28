using ForeScore.Models.CourseModels;
using ForeScore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForeScore.Contracts;
using System.Net;

namespace ForeScore.WebMVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var service = CreateCourseService();
            var courses = service.GetAllCourses();
            return View(courses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseCreate course)
        {
            var service = CreateCourseService();

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            if (service.CreateCourse(course))
            {
                TempData["SaveResult"] = "Course was successfully created.";
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Details(int id)
        {
            var service = CreateCourseService();

            var model = service.GetCourseById(id);

            if(model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();

            var entity = service.GetCourseById(id);

            if(entity == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var model = new CourseEdit
            {
                Address = entity.Address,
                EmailAddress = entity.EmailAddress,
                City = entity.City,
                ZipCode = entity.ZipCode,
                Holes = entity.Holes,
                Name = entity.Name,
                Par = entity.Par,
                PhoneNumber = entity.PhoneNumber,
                Rating = entity.Rating,
                Slope = entity.Slope,
                StateOfResidence = entity.StateOfResidence,
                Website = entity.Website,
                CourseId = entity.CourseId,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (model.CourseId != id)
            {
                ModelState.AddModelError("", "Entered ID and the model ID do not match.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var service = CreateCourseService();
                service.EditCourse(model);
                TempData["SaveResult"] = "Course was successfully updated.";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Updates could not be saved.";
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateCourseService();

            var model = service.GetCourseById(id);

            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(int id)
        {
            var service = CreateCourseService();

            if (service.DeleteCourse(id))
            {
                TempData["SaveResult"] = "Course successfully deleted.";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Course could not successfully be deleted.";
            return View();
        }

        private CourseServices CreateCourseService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CourseServices(userId);
            return service;
        }
    }
}