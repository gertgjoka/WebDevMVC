using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Service
{
    public interface IEntityService<T> where T : BaseEntity
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);

        IEnumerable<T> Search (Expression<Func<T, bool>> Predicate);
    }
}
