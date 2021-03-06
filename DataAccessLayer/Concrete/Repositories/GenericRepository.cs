using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<TEntity,TContext> : IRepository<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext:DbContext,new()
    {
        TContext context = new TContext();
        DbSet<TEntity> _object;
        public GenericRepository()
        {
            _object = context.Set<TEntity>();
        }
        public void Delete(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Insert(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public List<TEntity> GetAll()
        {
            return _object.ToList();
        }


        public void Update(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
