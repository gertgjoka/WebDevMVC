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
