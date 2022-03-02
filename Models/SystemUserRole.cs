using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SystemUserRole
    {
        public int SystemUserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpyDate { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }

        public virtual SystemRole Role { get; set; }
    }
}
