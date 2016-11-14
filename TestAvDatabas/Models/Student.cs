using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAvDatabas.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        //Foreign key for Standard
        public int StandardId { get; set; }

        public Standard Standard { get; set; }

        public virtual ICollection<IceCream> IceCream { get; set; }
    }

     public class Teacher
    {
        public int TeacherID { get; set; }
        public string StudentName { get; set; }

        //Foreign key for Standard
        //public int StandardId { get; set; }

        public Standard Standard { get; set; }

        //public virtual ICollection<IceCream> IceCream { get; set; }
    }

}