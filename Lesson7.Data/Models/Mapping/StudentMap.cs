using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lesson7.Data.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NrAmzes)
                .HasMaxLength(10);

            this.Property(t => t.Emri)
                .HasMaxLength(50);

            this.Property(t => t.Mbiemri)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NrAmzes).HasColumnName("NrAmzes");
            this.Property(t => t.Emri).HasColumnName("Emri");
            this.Property(t => t.Mbiemri).HasColumnName("Mbiemri");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.TipiIStudentit).HasColumnName("TipiIStudentit");

            // Relationships
            this.HasOptional(t => t.StudentType)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.TipiIStudentit);

        }
    }
}
