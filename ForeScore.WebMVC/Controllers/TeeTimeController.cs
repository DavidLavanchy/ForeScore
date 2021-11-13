using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForeScore.WebMVC.Controllers
{
    [Authorize]
    public class TeeTimeController : Controller
    {
        // GET: TeeTime
        public ActionResult Index()
        {
            return View();
        }
    }
}