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
                var item = _studentRepositoryp.GetModel();
                if(item == null)
                {
                    return Ok("No Record In Table");
                }
                return Ok(item);
            }
            catch(Exception e)
            {
                return Ok("");
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

        public IHttpActionResult UpdateStudent([FromBody]Student student,int id)

        {
            // var item = _studentRepositoryp.GetModelById(id);
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_studentRepositoryp.UpdateModel(student));
                }
            }
            catch(Exception e)
            {

            }
            

            //if(item == true)
            //{
            //    return Ok(item);
            //}
            return BadRequest("Data Not Found");
        }

        [HttpGet]
        
        public IHttpActionResult getStudentById(int id)
        {
            var Item = _studentRepositoryp.GetModelById(id);
            if(Item!=null)
            {
                return Ok(Item);
            }
            return BadRequest ("Student Not Found ");
        }
        


    }
}
