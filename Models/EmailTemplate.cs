using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class EmailTemplate
    {
        public int EmailTemplateId { get; set; }
        public string GroupType { get; set; }
        public string EmailType { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public string Subject { get; set; }
    }
}
