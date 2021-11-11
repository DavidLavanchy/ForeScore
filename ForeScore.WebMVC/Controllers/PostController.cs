using ForeScore.Models.PostModels;
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

        public ActionResult SelectRound()
        {
            var service = CreateRoundService();

            PostCreateViewModel viewModel = new PostCreateViewModel();

            viewModel.Rounds = service.GetAllRoundsByUserId();

            viewModel.NullRound = null;

            return View(viewModel);
        }

        public ActionResult CreatePost(int? id)
        {
            var service = CreateRoundService();
            PostCreate viewModel = new PostCreate();

            if (id == null)
            {
                viewModel.RoundDetail = service.CreateNullRound();
                viewModel.RoundId = null;

                return View(viewModel);
            }

            viewModel.RoundId = id;
            viewModel.RoundDetail = service.GetRoundById(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            var service = CreatePostService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Round was successfully created.";
                return RedirectToAction("Index");
            }

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
    }
}