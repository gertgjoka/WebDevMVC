using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Service
{
    public interface IStudentService : IEntityService<Student>
    {
        Student GetById(int id, bool LoadRelated);

        Student GetBestStudent();
    }
}
