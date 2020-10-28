
using IRepository.IRepository;
using Ninject;

using System;
using System.Windows.Forms;

namespace StudentWindowsFormApplication
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IKernel getkernal;
        
        public LoginForm(IKernel kernel)
        {
            _userRepository = kernel.Get<IUserRepository>();
            getkernal = kernel;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                var emai = email.Text;
                var pass = password.Text;
                var Item =_userRepository.ValidateUser(emai, pass);
               
                if (Item != null)
                { 
                    var getUserid = Item.UserId;
                    AddStudent addStudent = new AddStudent(getkernal,getUserid);
                    addStudent.Show();

                }
                else
                    MessageBox.Show("Record not Exist:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsValid()
        {
           if(email.Text == string.Empty)
            {
                MessageBox.Show("Email is Required","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
