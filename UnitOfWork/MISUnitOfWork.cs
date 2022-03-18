using Microsoft.EntityFrameworkCore;
using SPRA_SchJob.Repository;
using System;
using System.Collections;
using System.Transactions;

namespace SPRA_SchJob.UnitOfWork
{
    public class MISUnitOfWork<TContext> : IMISUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly DbContext __context;
        private TransactionScope __transaction;

        private bool __disposed;
        private Hashtable __repositories;

        public MISUnitOfWork(TContext sContext)
        {
            __context = sContext;
        }

        public void BeginTran()
        {
            __transaction = new TransactionScope();
        }

        public void Commit()
        {
            // For EF Entity only
            __context.SaveChanges();

            if (__transaction != null)
            {
                __transaction.Complete();
            }
        }

        public void Rollback()
        {
            if (__transaction != null)
            {
                __transaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!__disposed)
            {
                if (disposing)
                {
                    //__context.Dispose();

                    if (__transaction != null)
                        __transaction.Dispose();
                }
            }

            __disposed = true;
        }

        public IMISRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (__repositories == null)
            {
                __repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!__repositories.ContainsKey(type))
            {
                var repositoryType = typeof(MISRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(TEntity)), __context);

                __repositories.Add(type, repositoryInstance);
            }

            return (IMISRepository<TEntity>)__repositories[type];
        }

    }
}