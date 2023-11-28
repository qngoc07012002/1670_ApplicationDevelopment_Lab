using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _1670_ApplicationDevelopment_Lab.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        internal DbSet<T> dbSet { get; set; }

        public Repository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperty = null)
        {
           IQueryable<T> query = dbSet.Where(filter);
            if (!String.IsNullOrEmpty(includeProperty))
            {
                query.Include(includeProperty).ToList();
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            if (!String.IsNullOrEmpty(includeProperty))
            {
                query.Include(includeProperty).ToList();
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }


    }
}
