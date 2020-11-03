using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.WebMvc.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index(string to,string message)
        {
            return View();
        }
    }
}