using CodeWork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CodeWork.Dal
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);

            entity.AddedDate = DateTime.Now;

            context.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChangesAsync();

            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression = null, string include = "")
        {
            if (!string.IsNullOrEmpty(include))
                return expression == null
                    ? context.Set<TEntity>().Include(include).FirstOrDefault()
                    : context.Set<TEntity>().Include(include).SingleOrDefault(expression);
            else
                return expression == null
                    ? context.Set<TEntity>().AsNoTracking().FirstOrDefault()
                    : context.Set<TEntity>().AsNoTracking().SingleOrDefault(expression);
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                              ? context.Set<TEntity>().AsNoTracking().ToList()
                              : context.Set<TEntity>().AsNoTracking().Where(expression).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            var tempEntity = context.Entry<TEntity>(entity);
            tempEntity.State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        
    }
}
