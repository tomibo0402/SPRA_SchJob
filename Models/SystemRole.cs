using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SystemRole
    {
        public SystemRole()
        {
            SystemUserRoles = new HashSet<SystemUserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }

        public virtual ICollection<SystemUserRole> SystemUserRoles { get; set; }
    }
}
