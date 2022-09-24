using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Report.Data.Repository.Concrete.EfCore
{
    public class EfRepositoryBase<T> : IRepository<T>
         where T : IEntity
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;
        public EfRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public bool Add(T entity)
        {
            entity.CreationDate = DateTime.Now;
            _dbSet.Add(entity);

            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);

            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public T Get(Expression<Func<T, bool>> filter, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }

        public T Get(Guid id, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(p => p.Id == id);

            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includes)
        {
            IQueryable<T> tList = _dbSet;
            if (filter != null)
                tList = tList.Where(filter);

            foreach (string include in includes)
            {
                tList = tList.Include(include);
            }
            return tList;
        }

        public bool Update(T entity)
        {
            if (_dbSet.Local.Any(p => p.Id == entity.Id))
            {
                T localEntity = _dbSet.Local.First(p => p.Id == entity.Id);

                if (Object.ReferenceEquals(localEntity, entity) == false)
                    localEntity = entity;
            }
            else
            {
                _dbSet.Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;

            return _dbContext.SaveChanges() > 0 ? true : false;
        }

    }
}
