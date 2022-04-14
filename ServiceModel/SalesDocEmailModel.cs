using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.ServiceModel
{
    public class SalesDocEmailModel
    {
        public int ApeuDocId { get; set; }
        public string DocType { get; set; }
        public string DevelopmentNo { get; set; }
        public int? DevelopmentId { get; set; }
        public int AssignedUser { get; set; }
        public string DevelopmentNameEng { get; set; }
        public string DevelopmentNameChi { get; set; }
        public DateTime? ReceivedDate { get; set; }
    }
}
