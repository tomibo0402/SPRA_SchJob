using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.ServiceModel
{
    public class EmailSendingModel
    {
        public int ApeuDocID { get; set; }
        public int EmailRecordID { get; set; }
        public string DocType { get; set; }
        public int UserID { get; set; }
        public string Post { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string EmailAddress { get; set; }
    }
}
