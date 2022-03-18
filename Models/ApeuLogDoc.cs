using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class ApeuLogDoc
    {
        public int ApeuDocId { get; set; }
        public int ApeuLogId { get; set; }
        public string DocType { get; set; }
        public string DocName { get; set; }
        public string DocSeq { get; set; }
        public string DocRef { get; set; }
        public string DocRef2 { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public int? TotalNoOfUnits { get; set; }
        public DateTime? FirstDateSales { get; set; }
        public string IsEmailSent { get; set; }
    }
}
