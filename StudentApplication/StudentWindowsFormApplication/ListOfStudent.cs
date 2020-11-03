using DtoLayer.DTOModel;
using IRepository.IRepository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;

namespace StudentWindowsFormApplication
{
    public partial class ListOfStudent : Form
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IKernel getkernel;
        int getuserId;
        public ListOfStudent(IKernel kernel,int userId)
        {  
            _studentRepository = kernel.Get<IStudentRepository>();
            getkernel = kernel;
            getuserId = userId;
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex == 9)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    var studentid = Convert.ToInt32(row.Cells[0].Value);
                    UpdateStudent updateStudent = new UpdateStudent(getkernel,studentid, getuserId);
                    updateStudent.Show();

                }
                else { 
               
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var studentid = Convert.ToInt32(row.Cells[0].Value);
                    var Item = _studentRepository.DeleteModel(studentid);
                    if (Item == true)
                    {
                        refresh();
                    }
                }
        }
        }
        private void ListOfStudent_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            Pager page = new Pager();
            page.length = 10000000;
            page.start = 0;
            page.UserId = getuserId;
            dataGridView1.AutoGenerateColumns = false;
            var StudentModel = _studentRepository.GettAllStudents(page);
         
            dataGridView1.DataSource = _studentRepository.GettAllStudents(page);
            
            foreach (var item in StudentModel)
            {
                var n = (FullStudentDto)(item);
                this.CourseName.DisplayMember = "CourseName";
                this.CourseName.ValueMember = "CourseId";
                CourseName.DataSource = n.ListStudentCourses;
            }

        }
    }
}
