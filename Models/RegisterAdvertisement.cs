﻿using System;
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
        public string AdReviseFlag { get; set; }
        public DateTime? SbAvailableDate { get; set; }
        public DateTime? CheckDateAipo1 { get; set; }
        public int? Aipo1UserId { get; set; }
        public DateTime? CheckDateIpo1 { get; set; }
        public int? Ipo1UserId { get; set; }
        public DateTime? EndorsementDateSipo1 { get; set; }
        public int? Sipo1UserId { get; set; }
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
        public string DocRefNo { get; set; }
        public DateTime? CheckDateAipo2 { get; set; }
        public int? Aipo2UserId { get; set; }
        public DateTime? CheckDateIpo2 { get; set; }
        public int? Ipo2UserId { get; set; }
        public DateTime? CheckDateSipo2 { get; set; }
        public int? Sipo2UserId { get; set; }
    }
}
