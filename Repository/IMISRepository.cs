using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Repository
{
    public interface IMISRepository<T>
    {
        public IQueryable<T> GetEntity();
        public void Insert(List<T> Entity);
        public void Update(List<T> Entity);

        public T GetRecordById(int id);

    }
}
