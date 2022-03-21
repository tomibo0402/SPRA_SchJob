using Microsoft.Extensions.DependencyInjection;
using Quartz;
using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using SPRA_SchJob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SPRA_SchJob.Jobs
{
    public class JobScheduler : IJob
    {
        private readonly IEmailService<SPRA_SCHContext> _emailService;
        public JobScheduler(IEmailService<SPRA_SCHContext> emailService)
        {
            _emailService = emailService;
        }
        public Task Execute(IJobExecutionContext context)
        {

            JobDataMap dataMap = context.MergedJobDataMap;
            string methodName = dataMap.GetString("MethodName");

            var type = _emailService.GetType();
            var methodInfo = type.GetMethod(methodName);

            methodInfo.Invoke(_emailService, null);

            return Task.CompletedTask;
        }
    }
}
