﻿
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
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
