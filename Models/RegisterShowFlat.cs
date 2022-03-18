using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class RegisterShowFlat
    {
        public int RegisterShowFlatId { get; set; }
        public string DevelopmentNo { get; set; }
        public string SerialNo { get; set; }
        public string Unit { get; set; }
        public string FloorNo { get; set; }
        public string IsAvailableForView { get; set; }
        public DateTime? OnSiteCheckingDate { get; set; }
        public int? SiteInspectionBy { get; set; }
        public DateTime? DateReportSipo { get; set; }
        public int? SipoUserId { get; set; }
        public DateTime? ApprovalDateCipo { get; set; }
        public int? CipoUserId { get; set; }
        public string IsComplianceOrdinance { get; set; }
        public string IsComplianceGuideline { get; set; }
        public DateTime? CompleteDateIcau { get; set; }
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
        public int? InspectionId { get; set; }
        public string ShowFlatNo { get; set; }
        public string ShowFlatScale { get; set; }
        public string ShowFlatLocation { get; set; }
        public DateTime? CheckingCompletionDate { get; set; }
        public DateTime? AvailableDate { get; set; }
        public int? AssignedTo { get; set; }
    }
}
