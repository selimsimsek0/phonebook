using PhoneBook.Report.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Report.Data.Repository.Abstract
{
    public interface IRepository<T>
        where T : IEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includes);
        T Get(Expression<Func<T, bool>> filter, params string[] includes);
        T Get(Guid id, params string[] includes);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
