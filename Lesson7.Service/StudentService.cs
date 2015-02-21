using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lesson7.Service
{
    public class StudentService : EntityService<Student>, IStudentService
    {
        public StudentService(IContext Context)
            : base(Context)
        {

        }

        public override IEnumerable<Student> GetAll()
        {
            return DbSet.Include(s => s.StudentNotas).Include(s => s.Courses).AsEnumerable();
        }

        public override Student GetById(int id)
        {
            return DbSet.Include(s => s.StudentNotas).Include(s => s.Courses).Where(s => s.Id == id).FirstOrDefault();
        }

        public Student GetById(int id, bool LoadRelated)
        {
            if (!LoadRelated)
            {
                return base.GetById(id);
            }
            else
            {
                return GetById(id);
            }
        }


        public Student GetBestStudent()
        {
            return DbSet.OrderByDescending(s => s.StudentNotas.Average(n => n.Nota)).First();
        }
    }
}
