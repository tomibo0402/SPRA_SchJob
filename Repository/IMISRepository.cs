using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Repository
{
    public interface IMISRepository<T>
    {
        public IQueryable<T> GetEntity();
    }
}
