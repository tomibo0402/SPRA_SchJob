using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Repository
{
    public class MISRepository<TEntity> : IMISRepository<TEntity>
    where TEntity : class
    {
        private DbContext Context;
        public MISRepository(DbContext inContext)
        {
            Context = inContext;
        }

        public IQueryable<TEntity> GetEntity()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Insert(List<TEntity> Entity)
        {
            Context.Set<TEntity>().AddRange(Entity);
        }

        public void Update(List<TEntity> Entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetRecordById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }
}
