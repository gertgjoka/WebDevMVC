//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lesson7.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.StudentNotas = new HashSet<StudentNota>();
        }
    
        public int Id { get; set; }
        public string NrAmzes { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public Nullable<StudentType> TipiIStudentit { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StudentNota> StudentNotas { get; set; }
    }
}