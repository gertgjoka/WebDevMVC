using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lesson7.Data.Models.Mapping
{
    public class StudentNotaMap : EntityTypeConfiguration<StudentNota>
    {
        public StudentNotaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("StudentNota");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.CourseId).HasColumnName("CourseId");
            this.Property(t => t.Nota).HasColumnName("Nota");

            // Relationships
            this.HasOptional(t => t.Course)
                .WithMany(t => t.StudentNotas)
                .HasForeignKey(d => d.CourseId);
            this.HasOptional(t => t.Student)
                .WithMany(t => t.StudentNotas)
                .HasForeignKey(d => d.StudentId);

        }
    }
}
