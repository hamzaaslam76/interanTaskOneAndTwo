using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CourseController : ApiController
    {
        private CourseRepository _courseRepository;
        public CourseController()
        {
            _courseRepository = new CourseRepository();
        }
        [HttpGet]

        public IHttpActionResult GetAllCourse()
        {
           var Item= _courseRepository.GetModel();
            if(Item!=null)
            {
                return Ok(Item);
            }
            return BadRequest("Table Is Empty");
        }
    }
}
