using Microsoft.EntityFrameworkCore;
using PregledPlus.Data;
using System.Linq.Expressions;

namespace PregledPlus.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContext db;
        private DbSet<T> dbSet;
        public Repository(DBContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();

        }
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

           
            return query.ToList();
        }

        public void Add(T item)
        {
            dbSet.Add(item);

        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
