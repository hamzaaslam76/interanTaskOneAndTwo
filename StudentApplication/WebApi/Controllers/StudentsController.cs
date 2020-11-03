using DtoLayer.DTOModel;
using IRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace WebApi.Controllers
{
    public class StudentsController : BaseController
    {     
        private IStudentRepository _studentRepositoryp;
        public StudentsController(IStudentRepository studentRepository)
        {   
            _studentRepositoryp = studentRepository;
        }
        [Authorize(Roles ="SuperAdmin,Admin")]
        [HttpPost]
        //api/Student/?student=student&&courseid=arr
        public IHttpActionResult AddNewStudent([FromBody] StudentDto studentes , string courseID)
        {
            studentes.UserId = USER_ID;
            var courseList = courseID.Split(',').ToList();
            var item = _studentRepositoryp.AddStudent(studentes, courseList);
            if (item == true)
            {
                return Ok(item);
            }
            return BadRequest("Student not added");
        }
       [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost]
        public IHttpActionResult LoardData(Pager pager)
        {
            pager.UserId = USER_ID;
            List<FullStudentDto> StudentModel = _studentRepositoryp.GettAllStudents(pager);
            return Json(new { draw = pager.draw, recordsFiltered = StudentModel[0].TotalRecord, recordsTotal = StudentModel[0].TotalRecord, data = StudentModel });

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
        [Authorize(Roles ="SuperAdmin,Admin")]
        public IHttpActionResult UpdateStudent([FromBody] StudentDto student,string courseID)
        {
            student.UserId = USER_ID;
            var courseList = courseID.Split(',').ToList();
            return Ok(_studentRepositoryp.UpdateStudent(student, courseList));       
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
