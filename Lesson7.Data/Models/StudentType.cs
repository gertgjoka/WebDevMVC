using System;
using System.Collections.Generic;

namespace Lesson7.Data.Models
{
    public partial class StudentType
    {
        public StudentType()
        {
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Tipi { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
