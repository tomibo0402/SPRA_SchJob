using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPRA_SchJob.Services
{
    public interface IEmailService<SPRA_SchDBContext>
    {
        public void SEND_EMAIL();
        public void CREATE_SALES_DOC_EMAIL_RECORD();
        public List<CronJob> GetScheduler();
        public EmailConfig GetEmailConfig();

    }
}
