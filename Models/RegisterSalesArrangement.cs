using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class RegisterSalesArrangement
    {
        public int RegisterSalesArrangementId { get; set; }
        public int? ApeuDocId { get; set; }
        public string DocRefNo { get; set; }
        public string DevelopmentNo { get; set; }
        public string SerialNo { get; set; }
        public string SaType { get; set; }
        public DateTime? FirstDateSales { get; set; }
        public string TenderPeriod { get; set; }
        public DateTime? FirstPrintDate { get; set; }
        public DateTime? SiteInspectionDate { get; set; }
        public int? SiteInspectionBy { get; set; }
        public string AvailableToPublic { get; set; }
        public DateTime? CheckDateAipo1 { get; set; }
        public int? Aipo1UserId { get; set; }
        public DateTime? CheckDateIpo1 { get; set; }
        public int? Ipo1UserId { get; set; }
        public DateTime? EndorsementDateSipo1 { get; set; }
        public int? Sipo1UserId { get; set; }
        public DateTime? ApprovalDateCipo { get; set; }
        public int? CipoUserId { get; set; }
        public string IsComplianceOrdinance { get; set; }
        public string IsComplianceGuideline { get; set; }
        public DateTime? ReferralDateIcau { get; set; }
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
        public DateTime? IssuingDate { get; set; }
        public DateTime? CheckDateAipo2 { get; set; }
        public int? Aipo2UserId { get; set; }
        public DateTime? CheckDateIpo2 { get; set; }
        public int? Ipo2UserId { get; set; }
        public DateTime? EndorsementDateSipo2 { get; set; }
        public int? Sipo2UserId { get; set; }
        public string Status { get; set; }
        public string IsSuspensionOnly { get; set; }
        public int? AssignedTo { get; set; }
    }
}
