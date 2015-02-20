using System;
using System.Collections.Generic;

namespace Lesson7.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            this.StudentNotas = new List<StudentNota>();
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Numer { get; set; }
        public string Emer { get; set; }
        public virtual ICollection<StudentNota> StudentNotas { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
