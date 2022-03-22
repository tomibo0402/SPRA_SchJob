using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPRA_SchJob.Services
{
    public interface IEmailService<SPRA_SchDBContext>
    {
        public Task SRPE_ACCOUNT_NOTIFICATION();
        public Task NEW_RECEIVED_DOCUMENT_NOTIFICATION();

        public List<CronJob> GetScheduler();
        public EmailConfig GetEmailConfig();

    }
}
