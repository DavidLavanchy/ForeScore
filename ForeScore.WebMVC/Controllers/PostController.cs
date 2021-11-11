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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var service = CreatePostService();
            var viewModel = new PostsViewModel();

            viewModel.MyPosts = service.GetAllUsersPosts().ToList();
            viewModel.UsersFollowingPosts = service.GetFollowingsPosts().ToList();

            return View(viewModel);
        }

        private PostServices CreatePostService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PostServices(userId);
            return service;
        }
    }
}