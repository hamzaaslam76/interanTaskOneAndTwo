using Models.DataModels;
using Repository.DTOModel;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepositoryP _studentRepositoryp;
        public StudentsController()
        {
            _studentRepositoryp = new StudentRepositoryP();
        }

        [HttpPost]
        //api/Student/?student=student&&courseid=arr
        public IHttpActionResult AddNewStudent([FromBody]Student studentes , string courseID)
        {
           
            var item = _studentRepositoryp.AddStudent(studentes,courseID);
            if (item == true)
            {
                return Ok(item);
            }
            
           
            return BadRequest("Student not added");
        }

        [HttpGet]

        public IHttpActionResult getStudent()
        {
            try
            {
                List<FullStudentDto> item = _studentRepositoryp.GettAllStudents();
                if(item == null)
                {
                    return Ok("No Record In Table");
                }
                return Ok(item);
            }
            catch(Exception e)
            {
                return null;
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
         
            try
            {
                var check = _studentRepositoryp.DeleteModel(id);
                return Ok(check);
            }
            catch(Exception e)
            {
                return Ok("Student not Deleted");
            }
        }

        [HttpPut]

        public IHttpActionResult UpdateStudent([FromBody]Student student,string array)

        {
         
               if (ModelState.IsValid)
                {
                    return Ok(_studentRepositoryp.updateStudent(student,  array));
                }
              
            return BadRequest("Data Not Found");
        }

        [HttpGet]
        
        public IHttpActionResult getStudentById(int id)
        {
            var Item = _studentRepositoryp.SearchStudent(id);
            if(Item!=null)
            {
                return Ok(Item);
            }
            return BadRequest ("Student Not Found ");
        }
       
    }
}
