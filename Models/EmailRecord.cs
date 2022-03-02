using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class EmailRecord
    {
        public int EmailRecordId { get; set; }
        public int? ReceivedUser { get; set; }
        public string ReceivedUnit { get; set; }
        public string ReceivedPost { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string IsSent { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public DateTime? SendDatetime { get; set; }
    }
}
