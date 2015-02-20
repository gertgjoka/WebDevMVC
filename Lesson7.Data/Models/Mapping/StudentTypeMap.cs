using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Lesson7.Data.Models.Mapping
{
    public class StudentTypeMap : EntityTypeConfiguration<StudentType>
    {
        public StudentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tipi)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("StudentType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Tipi).HasColumnName("Tipi");
        }
    }
}
