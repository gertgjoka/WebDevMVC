using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lesson7.Model
{
    public interface IContext
    {
        IDbSet<Student> Students { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<StudentNota> StudentNotas { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
