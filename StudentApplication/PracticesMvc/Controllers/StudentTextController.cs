using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticesMvc.Controllers
{
    public class StudentTextController : Controller
    {
        // GET: StudentText

        public string name()
        {
            return "hamza aslam";
        }
        public string lastname(int id,string name)
        {
            return "hamza aslam";
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About(string name = null)
        {
            return View();
        }
    }
}