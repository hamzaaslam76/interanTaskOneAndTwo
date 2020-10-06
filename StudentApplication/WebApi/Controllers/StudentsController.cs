using Models.DataModels;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepository _studentRepository;
        public StudentsController()
        {
            _studentRepository = new StudentRepository();
        }

        [HttpPost]
        public IHttpActionResult AddNewStudent([FromBody]Student addstd)
        {
            var item = _studentRepository.AddStudent(addstd);
            if(item == true)
            {
                return Ok(item);
            }
            return BadRequest("Student not added");
        }

        [HttpGet]

        public IHttpActionResult getStudent()
        {
            var item = _studentRepository.getStudentList();
            return Ok(item);
        }
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var item = _studentRepository.deletestd(id);
            if(item == true)
            {
                return Ok(item);
            }
            return BadRequest("Student not Deleted");

        }
        [HttpPut]

        public IHttpActionResult UpdateStudent([FromBody]Student upstd,int id)
        {
            var item = _studentRepository.updateStudent(upstd, id);
            if(item == true)
            {
                return Ok(item);
            }
            return BadRequest("Data Not Found");
        }

        [HttpGet]
        
        public IHttpActionResult getStudentById(int id)
        {
            var Item = _studentRepository.SearchStudent(id);
            if(Item!=null)
            {
                return Ok(Item);
            }
            return BadRequest ("Student Not Found ");
        }
        


    }
}
