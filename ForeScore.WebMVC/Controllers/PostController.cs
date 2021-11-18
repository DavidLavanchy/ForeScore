using ForeScore.Models.CommentModels;
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

            viewModel.Rounds = service.GetAllPublicRoundsByUserId();

            viewModel.NullRound = null;

            return View(viewModel);
        }

        public ActionResult CreatePost(int id)
        {
            var service = CreateRoundService();
            PostCreate viewModel = new PostCreate();


            viewModel.RoundId = id;
            viewModel.RoundDetail = service.GetRoundById(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(PostCreate model)
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

        public ActionResult Details(int id)
        {
            var service = CreatePostService();


            var viewModel = service.GetPost(id);

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePostService();

            var viewModel = service.GetPost(id);

            var post = new PostEdit
            {
                Comments = viewModel.Comments,
                Content = viewModel.Content,
                Modified = null,
                OwnerId = viewModel.OwnerId,
                PostId = viewModel.PostId,
                RoundDetail = viewModel.RoundDetail,
                RoundId = viewModel.RoundId,
                Title = viewModel.Title,
            };

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePostService();

            if (service.EditPost(model))
            {
                TempData["SaveResult"] = "Post was successfully modified.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreatePostService();

            var viewModel = service.GetPost(id);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();

            if (service.DeletePost(id))
            {
                TempData["SaveResult"] = "Post successfully deleted";
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Comment(int id)
        {
            var service = CreatePostService();

            var viewModel = new CommentCreate();

            viewModel.PostDetail = service.GetPost(id);
            viewModel.PostId = id;

            return View(viewModel);
        }

        [HttpPost, ActionName("Comment")]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(CommentCreate model)
        {
            var service = CreateCommentService();

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Comment added";
                return RedirectToAction("Comment", model.PostId);
            }

            return View(model);
        }

        public ActionResult CommentDelete(int id)
        {
            var cmtService = CreateCommentService();

            var comment = cmtService.GetCommentById(id);

            var viewModel = new CommentDetail
            {
                Content = comment.Content,
                Name = comment.Name,
                OwnerId = comment.OwnerId,
                PostDetail = comment.PostDetail,
                PostId = comment.PostId,
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("CommentDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();

            if (service.DeleteComment(id))
            {
                TempData["SaveResult"] = "Comment deleted";
                return RedirectToAction("Index");
            }

            return View();
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

        private CommentServices CreateCommentService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CommentServices(userId);
            return service;
        }
    }
}