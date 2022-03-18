using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class RegisterTransactionMaster
    {
        public int RegisterTransactionMasterId { get; set; }
        public int? ApeuDocId { get; set; }
        public string DevelopmentNo { get; set; }
        public string SerialNo { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? UploadUser { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public int? AssignedTo { get; set; }
    }
}
