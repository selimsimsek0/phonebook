using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PhoneBook.Data.UnitOfWork.Abstract;
using System;

namespace PhoneBook.Data.UnitOfWork.Concrete
{
    public class EfUnitOfWorkBase : IUnitOfWork
    {
        DbContext _dbContext;
        IDbContextTransaction _transaction;
        public EfUnitOfWorkBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            if (_transaction is not null)
            {
                try
                {
                    _transaction.Commit();
                }
                catch (Exception exp)
                {
                    throw;
                }
                finally
                {
                    _transaction.Dispose();
                }
            }
        }

        public void NewTranaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void RollBack()
        {
            if (_transaction is not null)
            {
                try
                {
                    _transaction.Rollback();
                }
                catch (Exception exp)
                {
                    throw;
                }
                finally
                {
                    _transaction.Dispose();
                }
            }
        }
    }
}
