using Microsoft.AspNetCore.Mvc;
using SPRA_SchJob.Log;
using SPRA_SchJob.Models;
using SPRA_SchJob.Services;
using System;
using System.Collections.Generic;

namespace SPRA_SchJob.Controllers
{
    [Route("v1")]
    public class JobController : Controller
    {
        private IEmailService<SPRA_SCHContext> __EmailService;
        public JobController(IEmailService<SPRA_SCHContext> EmailService)
        {
            __EmailService = EmailService;

        }
        [Route("TriggerSendEmail")]
        public List<EmailRecord> SendEmail()
        {
            List<EmailRecord> rtn = null;
            try
            {
                Logger.Info("Send Email Service");
            }
            catch (Exception e)
            {
                Logger.Error("", e);
            }
            return rtn;
        }
    }
}
