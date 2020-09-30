using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModdels
{
   public  class student
    {
       public int studentId { get; set; }
       public string StudentName { get; set; }
       public string PhoneNumber { get; set; }
       public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        
    }
}