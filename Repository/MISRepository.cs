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
    }
}
