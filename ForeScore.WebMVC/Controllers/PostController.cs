using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForeScore.WebMVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}