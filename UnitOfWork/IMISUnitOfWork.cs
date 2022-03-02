using SPRA_SchJob.Repository;
using System;

namespace SPRA_SchJob.UnitOfWork
{
    public interface IMISUnitOfWork<TContext> : IDisposable
    {
        public void Commit();
        public void Rollback();
        public void BeginTran();
        public IMISRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    }
}