using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using SPRA_SchJob.EmailMessageBuilder;
using SPRA_SchJob.Jobs;
using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using SPRA_SchJob.Services;
using SPRA_SchJob.UnitOfWork;
using System;
using System.Net;
using System.Net.Mail;

namespace SPRA_SchJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SPRA_SCHContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConn")));
            services.AddScoped(typeof(IMISUnitOfWork<>), typeof(MISUnitOfWork<>));
            services.AddScoped(typeof(IEmailService<>), typeof(EmailService<>));

            EmailConfig config = JobsBuilder.GetEmailConfig(services);
            services.AddScoped<SmtpClient>((serviceProvider) =>
            {
                return new SmtpClient()
                {
                    //TODO:Temp email values
                    Host = config.SMTPAddress,
                    Port = config.SMTPPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                            "mistestingnec@gmail.com",
                            "nkcdreltkjmjirei"
                        //config.SenderAddress,
                        //config.SenderPassword
                        )
                };
            });

            services.AddScoped<EmailClient>();

            services.AddTransient<JobScheduler>();

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.BuildScheduler(services);
            });
            services.AddQuartzHostedService(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });


            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            loggerFactory.AddLog4Net();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
        }
    }
}
