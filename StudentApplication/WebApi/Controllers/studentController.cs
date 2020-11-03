


//using Newtonsoft.Json;
//using Repository.DTOModel;
//using Repository.Repository;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Results;
//using System.Web.Mvc;

//namespace WebApi.Controllers
//{
//    public class studentController : ApiController
//    {
//        private StudentRP _StudentRP;
//        public studentController()
//        {
//            _StudentRP = new StudentRP();
//        }
//        public IHttpActionResult Get(string name)
//        {
//            JsonResult result = new JsonResult();
//            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
//            using (var dbcotext = new context())
//            {
//                var stds = dbcotext.students.ToList();
//                return Ok(stds);
//                result.Data = new { success = true, NAME = name, students = JsonConvert.SerializeObject(stds) };
//            }
//            result.Data = new { succes = true, students = JsonConvert.SerializeObject(stds) };


//        }


//        public IHttpActionResult AddNewUser([FromBody] studentDTO ts)
//        {
//            _StudentRP.addstudent(ts);

//            return BadRequest("User Not Added");
//        }




//         return "success";





//         public IHttpActionResult
//        public IEnumerable<student> Get()
//        {
//            using (var dbcotext = new context())
//            {
//                return dbcotext.students.ToList();
//            }
//        }

//        public string Get()
//        {
//            return "hamza aslam";
//        }
//    }
//}
