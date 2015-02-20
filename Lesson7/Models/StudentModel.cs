using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson7.Models
{
    public class StudentModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NrAmzes { get; set; }
        
        [Required]
        public string Emri { get; set; }
        public string Mbiemri { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        public StudentType TipiIStudentit { get; set; }

        public virtual List<CourseModel> Courses { get; set; }
        public virtual List<StudentNotaModel> StudentNotas { get; set; }
    }

    public class CourseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Numer { get; set; }

        [Required]
        public string Emer { get; set; }
    }

    public class StudentNotaModel
    {

        [Required]
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> Nota { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}