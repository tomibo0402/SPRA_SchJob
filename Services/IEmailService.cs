using SPRA_SchJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Services
{
    public interface IEmailService<SPRA_SchDBContext>
    {
        public List<EmailRecord> TriggerSendEmail();
    }
}
