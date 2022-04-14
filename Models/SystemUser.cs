using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            SystemUserRoles = new HashSet<SystemUserRole>();
        }


        public int UserId { get; set; }
        public string Rank { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string Email { get; set; }
        public string UserUnit { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string MobileNo { get; set; }
        public string Status { get; set; }
        public int NoOfFailure { get; set; }
        public string IsReset { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? EffectiveDateFrom { get; set; }
        public DateTime? EffectiveDateTo { get; set; }
        public string HomePage { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }

        public virtual ICollection<SystemUserRole> SystemUserRoles { get; set; }
    }
}
