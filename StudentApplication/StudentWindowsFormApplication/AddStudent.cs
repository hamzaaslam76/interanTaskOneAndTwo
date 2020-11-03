using IRepository.IRepository;
using Models.DataModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentWindowsFormApplication
{
    public partial class AddStudent : Form
    {
        string ImageUrl = null;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        IKernel GetKernel;
        int Userid;
        public AddStudent(IKernel kernel, int userId)
        {
            _courseRepository = kernel.Get<ICourseRepository>();
            _studentRepository = kernel.Get<IStudentRepository>();
            GetKernel = kernel;
            Userid = userId;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Studentname = name.Text;
            student.StudentEmail = email.Text;
            student.DateOfBirth= dateofbirth.Text.ToString();
                List<int> values = new List<int>();
            foreach (var item in courseAdd.SelectedItems)
            {
                var n = (Course)(item);
               values.Add (n.CourseId);
            }
            student.PhoneNumber = phone.Text;
            student.Password = password.Text;
            student.ConfirmPawword = confiramPass.Text;
            student.UserId = Userid;
            student.ImageUrl = ImageUrl;
               
           if( _studentRepository.AddStudent(student, values))
            {
                MessageBox.Show("Student Added");
                clearField();
            }
           else
                MessageBox.Show("Student not added");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        { 
            courseAdd.DataSource = _courseRepository.GetModel();
            courseAdd.DisplayMember = "CourseName";
            courseAdd.ValueMember = "CourseId";
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListOfStudent listOfStudent = new ListOfStudent(GetKernel, Userid);
            listOfStudent.Show();
        }
        public void clearField()
        {
            name.Text = "";
            email.Text = "";
            phone.Text = "";
            password.Text = "";
            confiramPass.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choos Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                ImageUrl= Path.Combine(opf.FileName, Path.Combine(@"E:\InteranshipWork\TaskOneTwo\StudentApplication\StudentWindowsFormApplication\Image\", Path.GetFileName(opf.FileName)));
                File.Copy(opf.FileName, ImageUrl,true);
            }

        }
    }
}
