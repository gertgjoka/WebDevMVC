using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Lesson7.Service
{
    public class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected IContext Context;
        protected IDbSet<T> DbSet;

        public EntityService(IContext Context)
        {
            this.Context = Context;
            DbSet = Context.Set<T>();
        }
        public virtual T GetById(int id)
        {
            return DbSet.Where<T>(e => e.Id == id).FirstOrDefault();
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            { 
                throw new ArgumentNullException("entity"); 
            }
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }


        public virtual IEnumerable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
        {
            if (Predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return DbSet.Where(Predicate);
        }
    }
}
