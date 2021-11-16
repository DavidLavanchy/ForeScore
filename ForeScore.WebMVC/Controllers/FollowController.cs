using ForeScore.Models.FollowingModels;
using ForeScore.Models.ViewModels;
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
    public class FollowController : Controller
    {
        // GET: Follow
        public ActionResult Index()
        {
            var model = new FollowViewModel();

            var followerService = CreateFollowerService();
            var followService = CreateFollowingService();

            model.Following = followService.GetAllFollowings().ToList();
            model.Followers = followerService.GetFollowers().ToList();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var qkserv = CreateFollowingService();
            var userId = qkserv.GetUserId(id);

            var service = new UserCareerServices(userId);
            var roundService = new RoundServices(userId);
            var postService = new PostServices(userId);
            var followingService = new FollowingServices(userId);

            var model = service.ViewCareerStats();
            model.PostDetails = postService.GetAllUsersPosts().OrderByDescending(e => e.PostId).Take(5).ToList();
            model.RoundDetails = roundService.GetAllRoundsByUserIdAndDate().Take(5).ToList();
            model.Following = followingService.GetAllFollowings().OrderByDescending(e => e.FollowingId).Take(5).ToList();

            return View(model);

        }

        public ActionResult Create()
        {
            var service = CreateFollowingService();
            var viewModel = service.CreateFollowingAddModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FollowingAdd model)
        {
            var service = CreateFollowingService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.FollowCreate(model))
            {
                TempData["SaveResult"] = "User successfully followed.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateFollowingService();

            var viewModel = service.GetFollowingById(id);

            if (viewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFollowing(int id)
        {
            var service = CreateFollowingService();

            if (service.FollowDelete(id))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private FollowingServices CreateFollowingService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FollowingServices(userId);

            return service;
        }

        private FollowerServices CreateFollowerService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FollowerServices(userId);

            return service;
        }
    }
}