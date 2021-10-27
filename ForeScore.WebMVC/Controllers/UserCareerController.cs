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
            var userId = User.Identity.GetUserId();
            var service = new UserCareerServices(userId);

            var model = service.ViewCareerStats();
            return View(model);
        }
    }
}