using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SystemRoleFunction
    {
        public int RoleFunctionId { get; set; }
        public int RoleId { get; set; }
        public string FunctionNo { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string InsertFlag { get; set; }
        public string EditFlag { get; set; }
        public string DeleteFlag { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
    }
}
