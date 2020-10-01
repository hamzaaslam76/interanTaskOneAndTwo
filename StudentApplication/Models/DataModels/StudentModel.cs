using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
   public class Student
    {
        public int StudentId { get; set; }
        public string Studentname { get; set; }
        public string StudentEmail { get; set; }

       public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPawword { get; set; }

    }
}
