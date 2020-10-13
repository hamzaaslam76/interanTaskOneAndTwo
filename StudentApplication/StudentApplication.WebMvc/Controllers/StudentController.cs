
using Models.DataModels;
using Repository.DTOModel;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.WebMvc.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepositoryP _studentRepositoryp;
        private CourseRepository _courseRepository;
       public StudentController()
        {
            _studentRepositoryp = new StudentRepositoryP();
            _courseRepository = new CourseRepository();

        }
        // GET: Student
        public ActionResult Index(string ErrorMessage)
        { 
            if (ErrorMessage != "" && ErrorMessage != null)
            {
                ViewBag.message = ErrorMessage;
            }
          
                return View();   
        }
        [HttpPost]
        public ActionResult LoardData(Pager pager)
        {
            List<FullStudentDto> StudentModel = _studentRepositoryp.GettAllStudents(pager);

            return Json(new {draw = pager.draw ,recordsFiltered=StudentModel[0].TotalRecord,recordsTotal=StudentModel[0].TotalRecord,data=StudentModel},JsonRequestBehavior.AllowGet);

        }
        // Add Cources in AddStudent Form
        [HttpGet]
        public ActionResult AddStudent()
        {
            var Getcourses = _courseRepository.GetModel();
            
            return View(Getcourses);

        }
        [HttpPost]
        public ActionResult AddStudentInDtabase( Student studentes, string courseId)
        {
              var Item = _studentRepositoryp.AddStudent(studentes, courseId);
            return Json(Item,JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult EditId(int id)
        {
            FullStudentDtoo GetEditStudent = _studentRepositoryp.SearchStudent(id);
            return View(GetEditStudent);
        }
        [HttpPut]
        public ActionResult UpdateStudent(Student studentes,string courseId)
        {
           var Item= _studentRepositoryp.UpdateStudent(studentes, courseId);
            return Json(Item);
        }
        // Without StorProcedure Delete Student
        //public ActionResult DeleteStudent(int id)
        //{
        //    var Item = _studentRepositoryp.DeleteModel(id);
        //    if (!Item)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", new { s = "record Does Not Deleted" });
        //    }   
        //}  
         
        // Delete Student Using Store Procedure
        public ActionResult DeleteStudent(int id)
        {
            var Item = _studentRepositoryp.DleteStudent(id);
            if (Item)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { s = "record Does Not Deleted" });
            }
        }

    }
}