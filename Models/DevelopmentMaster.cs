using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class DevelopmentMaster
    {
        public int DevelopmentId { get; set; }
        public string DevelopmentNo { get; set; }
        public string DevelopmentNameEng { get; set; }
        public string DevelopmentNameChi { get; set; }
        public string PhaseNo { get; set; }
        public string PhaseNoChi { get; set; }
        public string PhaseNameEng { get; set; }
        public string PhaseNameChi { get; set; }
        public string RoadName { get; set; }
        public int? StreetNoNum { get; set; }
        public string StreetNoAlpha { get; set; }
        public string StreetNoExt { get; set; }
        public string Address { get; set; }
        public string PlannedArea1 { get; set; }
        public string PlannedArea2 { get; set; }
        public string HousingSchemeCode { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public int? TotalNoOfUnits { get; set; }
        public DateTime? FirstDateSales { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? SuspensionDate { get; set; }
        public string Status { get; set; }
    }
}
