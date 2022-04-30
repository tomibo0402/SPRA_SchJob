using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using SPRA_SchJob.Log;
using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using SPRA_SchJob.Services;
using System;
using System.Collections.Generic;

namespace SPRA_SchJob.Jobs
{
    public static class JobsBuilder
    {
        private const string _sendEmailServiceName = "NEW_RECEIVED_DOCUMENT_NOTIFICATION";
        public static void BuildScheduler(this IServiceCollectionQuartzConfigurator q, IServiceCollection services)
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var emailService = serviceProvider.GetService<IEmailService<SPRA_SCHContext>>();

                List<CronJob> cronJobs = emailService.GetScheduler();
                Logger.Info("Init Scheduler");


                foreach (var cj in cronJobs)
                {
                    var serviceName = cj.ServiceName;
                    serviceName = serviceName.Contains(_sendEmailServiceName) ? _sendEmailServiceName : serviceName;

                    q.ScheduleJob<JobScheduler>(trigger => trigger
                       .StartNow()
                       .WithCronSchedule(cj.CronExpression)
                       .UsingJobData("MethodName", serviceName)
                    );
                }

                Logger.Info($"Finish Init with {cronJobs.Count} jobs");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }
        public static EmailConfig GetEmailConfig(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var emailService = serviceProvider.GetService<IEmailService<SPRA_SCHContext>>();

            return emailService.GetEmailConfig();
        }
    }
}
