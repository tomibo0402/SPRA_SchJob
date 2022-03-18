using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class CodeTable
    {
        public int CodeId { get; set; }
        public string CodeMasterType { get; set; }
        public string GroupType { get; set; }
        public string CodeType { get; set; }
        public string Code { get; set; }
        public string CodeDescriptionEng { get; set; }
        public string IsSystemUse { get; set; }
        public string IsDefault { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
    }
}
