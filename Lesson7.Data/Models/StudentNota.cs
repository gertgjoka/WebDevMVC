using System;
using System.Collections.Generic;

namespace Lesson7.Data.Models
{
    public partial class StudentNota
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> Nota { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
