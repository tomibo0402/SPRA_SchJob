using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPRA_SchJob.Models;
using SPRA_SchJob.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SPRA_SchJob.Controllers
{
    [Route("v1")]
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private IEmailService<SPRA_SCHContext> __EmailService;
        public JobController(ILogger<JobController> logger, IEmailService<SPRA_SCHContext> EmailService)
        {
            _logger = logger;
            __EmailService = EmailService;

        }
        [Route("TriggerSendEmail")]
        public List<EmailRecord> SendEmail()
        {
            return __EmailService.TriggerSendEmail();
        }
    }
}
