using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Lesson7.Data.Models.Mapping;

namespace Lesson7.Data.Models
{
    public partial class Lesson7Context : DbContext
    {
        static Lesson7Context()
        {
            Database.SetInitializer<Lesson7Context>(null);
        }

        public Lesson7Context()
            : base("Name=Lesson7Context")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentNota> StudentNotas { get; set; }
        public DbSet<StudentType> StudentTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new StudentNotaMap());
            modelBuilder.Configurations.Add(new StudentTypeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
