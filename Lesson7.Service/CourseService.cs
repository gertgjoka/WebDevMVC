using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Service
{
    public class CourseService : EntityService<Course>, ICourseService
    {
        public CourseService(IContext Context)
            : base(Context)
        {

        }
    }
}
