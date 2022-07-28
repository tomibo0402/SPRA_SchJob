using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class EmailRecipientSetting
    {
        public int EmailRecipientSettingId { get; set; }
        public int EmailTemplateId { get; set; }
        public string EmailCategory { get; set; }
        public string DocType { get; set; }
        public string DocDesc { get; set; }
        public string SendToRank { get; set; }
        public string SendToPost { get; set; }
        public string Remarks { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
    }
}
