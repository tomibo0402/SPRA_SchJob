using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class ApeuLog
    {
        public int ApeuLogId { get; set; }
        public string SystemNo { get; set; }
        public DateTime? OpenDatetime { get; set; }
        public DateTime? StampDatetime { get; set; }
        public DateTime? ReceivedSrpeDatetime { get; set; }
        public int? DevelopmentId { get; set; }
        public string DevelopmentNo { get; set; }
        public string WebSites { get; set; }
        public string ImuSendFlag { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public string ReceivedFrom { get; set; }
    }
}
