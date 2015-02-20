using System;
using System.Collections.Generic;

namespace Lesson7.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            this.StudentNotas = new List<StudentNota>();
            this.Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string NrAmzes { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public Nullable<int> TipiIStudentit { get; set; }
        public virtual StudentType StudentType { get; set; }
        public virtual ICollection<StudentNota> StudentNotas { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
