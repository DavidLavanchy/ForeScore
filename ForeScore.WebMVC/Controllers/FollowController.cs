﻿using ForeScore.Models.ViewModels;
using ForeScore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForeScore.WebMVC.Controllers
{
    public class FollowController : Controller
    {
        // GET: Follow
        public ActionResult Index()
        {
            var model = new FollowViewModel();

            var followerService = CreateFollowerService();
            var followService = CreateFollowingService();

            model.Following = followService.GetAllFollowings();
            model.Followers = followerService.GetFollowers();
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