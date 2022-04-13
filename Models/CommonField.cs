using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Models
{
    public class CommonField
    {
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
    }
}
