using DtoLayer.DTOModel;
using IRepository.IRepository;
using Models.DataModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentWindowsFormApplication
{
   
    public partial class UpdateStudent : Form
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        IKernel getKernal;
        int getStudentid;
        int getUserId;
        public UpdateStudent(IKernel kernel, int Id, int userId)
        {
            _courseRepository=kernel.Get<ICourseRepository>();
            _studentRepository= kernel.Get<IStudentRepository>();
            getKernal = kernel;
            getStudentid = Id;
            getUserId = userId;
            InitializeComponent();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
           
            var Student= _studentRepository.SearchStudent(getStudentid);
            courseAdd.DataSource = Student.Listcourses;
            courseAdd.DisplayMember = "CourseName";
            courseAdd.ValueMember = "CourseId";
            List<int> MatchValue = new List<int>();
            foreach (var item in courseAdd.Items)
            {
               
                var n = (CourseDto)(item);
                foreach (var stdCourse in Student.StudentCourses)
                {
                    if (n.CourseId == stdCourse.CourseId)
                    {
                        MatchValue.Add(courseAdd.Items.IndexOf(item));
                       
                    }
                   
                }
            }
           foreach(var select in MatchValue)
            {
                courseAdd.SetSelected(select, true);
            }
            
            name.Text = Student.Studentname;
            email.Text = Student.StudentEmail;
            dateofbirth.Text = Student.DateOfBirth;
            phone.Text = Student.PhoneNumber;
            password.Text = Student.Password;
            confiramPass.Text = Student.ConfirmPawword;
        }

        private void confiramPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentDto student = new StudentDto();
            student.StudentId = getStudentid;
            student.Studentname = name.Text;
            student.StudentEmail = email.Text;
            student.DateOfBirth = dateofbirth.Text.ToString();
            List<int> values = new List<int>();
            foreach (var item in courseAdd.SelectedItems)
            {
                var n = (CourseDto)(item);
                values.Add(n.CourseId);
            }
            student.PhoneNumber = phone.Text;
            student.Password = password.Text;
            student.ConfirmPawword = confiramPass.Text;
            student.UserId = getUserId;

            if (_studentRepository.UpdateStudent(student, values))
            {
                MessageBox.Show("Record Updated");
                clearField();
            }
            else
            {
                MessageBox.Show("Record not  Updated");
            }


        }
        public void clearField()
        {
            name.Text ="";
            email.Text = "";
            phone.Text = "";
            password.Text = "";
            confiramPass.Text = "";
        }
    }
}
