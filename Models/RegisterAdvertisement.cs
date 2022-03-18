using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class RegisterAdvertisement
    {
        public int RegisterAdvertisementId { get; set; }
        public int? ApeuDocId { get; set; }
        public string DevelopmentNo { get; set; }
        public string SerialNo { get; set; }
        public string AdType { get; set; }
        public string AdName { get; set; }
        public DateTime? PrintDate { get; set; }
        public string AdvReviseFlag { get; set; }
        public DateTime? SbAvailableDate { get; set; }
        public DateTime? CheckDateAipo { get; set; }
        public int? AipoUserId { get; set; }
        public DateTime? CheckDateIpo { get; set; }
        public int? IpoUserId { get; set; }
        public DateTime? EndorsementDateSipo { get; set; }
        public int? SipoUserId { get; set; }
        public DateTime? ApprovalDateCipo { get; set; }
        public int? CipoUserId { get; set; }
        public string IsCompianceOrdinance { get; set; }
        public string IsCompianceGuideline { get; set; }
        public DateTime? ReferralDateIcau { get; set; }
        public string AdPublishByVendor { get; set; }
        public int? CaseId { get; set; }
        public string Remarks { get; set; }
        public string RemarksReturn { get; set; }
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
