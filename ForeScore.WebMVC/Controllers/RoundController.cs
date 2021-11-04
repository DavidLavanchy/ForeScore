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
    public class RoundController : Controller
    {
        // GET: Round
        public ActionResult Index()
        {
            var service = CreateRoundService();
            service.GetAllRoundsByUserId();
            return View(service);
        }

        private RoundServices CreateRoundService()
        {
            var userId = User.Identity.GetUserId();
            var service = new RoundServices(userId);
            return service;
        }
    }
}