using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.ServiceModel
{
    public class EmailConfig
    {
        public string SMTPAddress { get; set; }
        public int SMTPPort { get; set; }
        public string SenderAddress { get; set; }
        public string SenderPassword { get; set; }
    }
}
