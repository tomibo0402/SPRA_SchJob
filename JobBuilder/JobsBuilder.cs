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

        public static void BuildScheduler(this IServiceCollectionQuartzConfigurator q, IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var emailService = serviceProvider.GetService<IEmailService<SPRA_SCHContext>>();

            List<CronJob> cronJobs = emailService.GetScheduler();
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler sched = factory.GetScheduler().GetAwaiter().GetResult();
            Logger.Info("Init Scheduler");
            foreach (var cj in cronJobs)
            {
                q.ScheduleJob<JobScheduler>(trigger => trigger
                   .StartNow()
                   .WithCronSchedule(cj.CronExpression)
                   .UsingJobData("MethodName", cj.ServiceName)
                );
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
