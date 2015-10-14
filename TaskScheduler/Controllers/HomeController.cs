using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Task Scheduler - Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Task Scheduler - Contant and Support";

            return View();
        }
    }
}