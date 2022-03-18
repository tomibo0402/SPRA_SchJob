using System;
using System.Collections.Generic;

#nullable disable

namespace SPRA_SchJob.ServiceModel
{
    public class CronJob
    {
        public string ServiceName { get; set; }
        public string CronExpression { get; set; }
    }
}
