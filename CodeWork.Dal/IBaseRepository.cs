using CodeWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeWork.Dal
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        List<T> List(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression = null, string include = "");
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
