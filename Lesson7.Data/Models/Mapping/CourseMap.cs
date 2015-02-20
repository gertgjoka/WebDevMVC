using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lesson7.Data.Models.Mapping
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Numer)
                .HasMaxLength(10);

            this.Property(t => t.Emer)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Course");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Numer).HasColumnName("Numer");
            this.Property(t => t.Emer).HasColumnName("Emer");

            // Relationships
            this.HasMany(t => t.Students)
                .WithMany(t => t.Courses)
                .Map(m =>
                    {
                        m.ToTable("StudentCourse");
                        m.MapLeftKey("CourseId");
                        m.MapRightKey("StudentId");
                    });


        }
    }
}
