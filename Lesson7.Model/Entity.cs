using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class BaseEntity : IEntity<int>
    {
        public virtual int Id { get; set; }
    }

    public abstract class Entity<T> : BaseEntity
    {
        
    }
}
