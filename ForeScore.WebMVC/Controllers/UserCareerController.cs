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
    public class UserCareerController : Controller
    {
        // GET: UserCareer
        public ActionResult Index()
        {
            var service = CreateUserCareerService();
            var roundService = CreateRoundService();
            var postService = CreatePostService();
            var followingService = CreateFollowingService();

            var model = service.ViewCareerStats();
            model.PostDetails = postService.GetAllUsersPosts().OrderByDescending(e => e.PostId).Take(5).ToList();
            model.RoundDetails = roundService.GetAllRoundsByUserIdAndDate().Take(5).ToList();
            model.Following = followingService.GetAllFollowings().OrderByDescending(e => e.FollowingId).Take(5).ToList();
            return View(model);
        }

        private PostServices CreatePostService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PostServices(userId);
            return service;
        }

        private RoundServices CreateRoundService()
        {
            var userId = User.Identity.GetUserId();
            var service = new RoundServices(userId);
            return service;
        }

        private UserCareerServices CreateUserCareerService()
        {
            var userId = User.Identity.GetUserId();
            var service = new UserCareerServices(userId);
            return service;
        }

        private FollowingServices CreateFollowingService()
        {
            var userId = User.Identity.GetUserId();
            var service = new FollowingServices(userId);
            return service;
        }
    }
}