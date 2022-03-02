using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.Models
{
    public partial class SystemParameter
    {
        public int SystemParameterId { get; set; }
        public string ParameterType { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterDescription { get; set; }
        public string ParameterValue { get; set; }
        public string ParameterValue2 { get; set; }
        public string IsEncrypted { get; set; }
        public string IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ActionId { get; set; }
    }
}
