﻿

using System.Linq.Expressions;

namespace _1670_ApplicationDevelopment_Lab.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperty = null);

        T Get(Expression<Func<T,bool>> filter, string? includeProperty = null);

        void Add(T entity);

        void Remove(T entity);

    }
}
