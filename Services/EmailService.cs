
using SPRA_SchJob.Log;
using SPRA_SchJob.Models;
using SPRA_SchJob.ServiceModel;
using SPRA_SchJob.UnitOfWork;
using SPRA_SchJob.EmailMessageBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Transactions;
using System;
using System.Threading.Tasks;

namespace SPRA_SchJob.Services
{
    public class EmailService<SPRA_SCHContext> : IEmailService<SPRA_SCHContext>
    {
        private readonly IMISUnitOfWork<SPRA_SCHContext> __misunitofwork;
        private readonly EmailClient __emailClient;
        public EmailService(IMISUnitOfWork<SPRA_SCHContext> unitOfWork, EmailClient emailClient = null)
        {
            __emailClient = emailClient;
            __misunitofwork = unitOfWork;
        }
        public async Task SRPE_ACCOUNT_NOTIFICATION()
        {
            Logger.Info("Running Create Email Record Schedule Job");
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var salesDocEmail = from aplog in __misunitofwork.GetRepository<ApeuLogDoc>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.DocType == "SRPE" && e.IsEmailSent == 'N')
                                        from email in __misunitofwork.GetRepository<SalesDocEmail>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.DocType == aplog.DocType)
                                        from ct in __misunitofwork.GetRepository<CodeTable>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.CodeMasterType == "APEU_DOC" && e.GroupType == "DOC_TYPE" && e.Code == email.DocType)
                                        from user in __misunitofwork.GetRepository<SystemUser>().GetEntity()
                                                   .Where(e => email.SendToPost == e.Post)
                                        from et in __misunitofwork.GetRepository<EmailTemplate>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.EmailTemplateId == email.EmailTemplateId)
                                        let messageValue = new List<object> { user.Name, user.Email, email.DocType }
                                        select new DocEmailModel
                                        {
                                            ApeuDocID = aplog.ApeuDocId,
                                            UserID = user.UserId,
                                            Post = user.Post,
                                            Subject = et.Subject,
                                            Message = __emailClient.BuildMessage(et.Content, messageValue),
                                            EmailAddress = user.Email
                                        };
                    if (!salesDocEmail.Any())
                        return;

                    CreateEmailRecordAndUpdateRelatedFields(salesDocEmail);

                    await SendEmail(salesDocEmail);
                    tx.Complete();
                }
                catch (Exception e)
                {
                    __misunitofwork.Rollback();
                    tx.Dispose();
                    Logger.Error(e.Message);
                }
            }
        }
        public async Task NEW_RECEIVED_DOCUMENT_NOTIFICATION()
        {

            Logger.Info("Running Create Email Record Schedule Job");
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var salesDocEmail = from aplog in __misunitofwork.GetRepository<ApeuLogDoc>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.DocType != "SRPE" && e.IsEmailSent == 'N')
                                        from email in __misunitofwork.GetRepository<SalesDocEmail>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.DocType == aplog.DocType)
                                        from ct in __misunitofwork.GetRepository<CodeTable>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.CodeMasterType == "APEU_DOC" && e.GroupType == "DOC_TYPE" && e.Code == email.DocType)
                                        from user in __misunitofwork.GetRepository<SystemUser>().GetEntity()
                                                   .Where(e => email.SendToPost == e.Post)
                                        from et in __misunitofwork.GetRepository<EmailTemplate>().GetEntity()
                                                   .Where(e => e.IsDeleted == "N" && e.EmailTemplateId == email.EmailTemplateId)
                                        let messageValue = new List<object> { user.Name, user.Email, email.DocType }
                                        select new DocEmailModel
                                        {
                                            ApeuDocID = aplog.ApeuDocId,
                                            UserID = user.UserId,
                                            Post = user.Post,
                                            Subject = et.Subject,
                                            Message = __emailClient.BuildMessage(et.Content, messageValue),
                                            EmailAddress = user.Email
                                        };
                    if (!salesDocEmail.Any())
                        return;

                    CreateEmailRecordAndUpdateRelatedFields(salesDocEmail);

                    await SendEmail(salesDocEmail);

                    tx.Complete();
                }
                catch (Exception e)
                {
                    __misunitofwork.Rollback();
                    tx.Dispose();
                    Logger.Error(e.Message);
                }
            }
        }


        public EmailConfig GetEmailConfig()
        {
            var config = __misunitofwork.GetRepository<SystemParameter>().GetEntity()
                .Where(e => e.ParameterType == "EMAIL" && e.IsDeleted == "N");
            return new EmailConfig
            {
                SenderAddress = config.Where(e => e.ParameterCode == "SENDER_ADDRESS").Select(e => e.ParameterValue).First(),
                SenderPassword = config.Where(e => e.ParameterCode == "SENDER_PW").Select(e => e.ParameterValue).First(),
                SMTPAddress = config.Where(e => e.ParameterCode == "EMAIL_SERVER").Select(e => e.ParameterValue).First(),
                SMTPPort = int.Parse(config.Where(e => e.ParameterCode == "EMAIL_PORT").Select(e => e.ParameterValue).First())
            };
        }

        public List<CronJob> GetScheduler()
        {
            return __misunitofwork.GetRepository<SystemParameter>().GetEntity()
                .Where(e => e.ParameterType == "SCHEDULE" && e.IsDeleted == "N")
                .Select(e => new CronJob
                {
                    ServiceName = e.ParameterCode,
                    CronExpression = e.ParameterValue
                }).ToList();
        }

        #region private

        private async Task SendEmail(IQueryable<DocEmailModel> docEmail)
        {
            Logger.Info("Running Send Email Schedule Job");
            DateTime currTime = DateTime.Now;
            var emailToSend = from email in __misunitofwork.GetRepository<EmailRecord>().GetEntity()
                                               .Where(e => e.IsDeleted == "N" && e.IsSent == "N")
                              from user in __misunitofwork.GetRepository<SystemUser>().GetEntity()
                                                 .Where(e => e.IsDeleted == "N" && email.ReceivedUser == e.UserId)
                              select new DocEmailModel
                              {
                                  EmailRecordID = email.EmailRecordId,
                                  EmailAddress = user.Email,
                                  UserID = user.UserId,
                                  Subject = email.Subject,
                                  Message = email.Content
                              };
            if (!emailToSend.Any())
                return;

            await __emailClient.SendMessage(emailToSend.ToList());

            // update email record is_sent
            (from ets in emailToSend
             from er in __misunitofwork.GetRepository<EmailRecord>().GetEntity().Where(e => e.EmailRecordId == ets.EmailRecordID)
             select er)
                    .ToList().ForEach(e =>
                    {
                        e.IsSent = "Y";
                        CommonTools.SetCommonFieldForUpdate(e);
                        e.SendDatetime = DateTime.Now;
                    });

            // update apeu log doc
            (from sde in docEmail
             from aplog in __misunitofwork.GetRepository<ApeuLogDoc>().GetEntity()
                                            .Where(e => e.ApeuDocId == sde.ApeuDocID)
             select aplog)
                .ToList().ForEach(e =>
                {
                    e.IsEmailSent = 'Y';
                    CommonTools.SetCommonFieldForUpdate(e);
                });

            __misunitofwork.Commit();
        }
        private void CreateEmailRecordAndUpdateRelatedFields(IQueryable<DocEmailModel> salesDocEmail)
        {

            //update register table
            (from sde in salesDocEmail
             from rpl in __misunitofwork.GetRepository<RegisterPriceList>().GetEntity()
                                  .Where(e => e.IsDeleted == "N" && e.ApeuDocId == sde.ApeuDocID).DefaultIfEmpty()
             from rsa in __misunitofwork.GetRepository<RegisterSalesArrangement>().GetEntity()
                                  .Where(e => e.IsDeleted == "N" && e.ApeuDocId == sde.ApeuDocID).DefaultIfEmpty()
             from rsb in __misunitofwork.GetRepository<RegisterSalesBrochure>().GetEntity()
                                  .Where(e => e.IsDeleted == "N" && e.ApeuDocId == sde.ApeuDocID).DefaultIfEmpty()
             from rsf in __misunitofwork.GetRepository<RegisterTransactionMaster>().GetEntity()
                                  .Where(e => e.IsDeleted == "N" && e.ApeuDocId == sde.ApeuDocID).DefaultIfEmpty()
             from ra in __misunitofwork.GetRepository<RegisterAdvertisement>().GetEntity()
                                   .Where(e => e.IsDeleted == "N" && e.ApeuDocId == sde.ApeuDocID).DefaultIfEmpty()
             select new
             {
                 userID = sde.UserID,
                 rpl,
                 rsa,
                 rsb,
                 rsf,
                 ra
             }).ToList().ForEach(e =>
             {
                 if (e.rpl != null) { e.rpl.AssignedTo = e.userID; CommonTools.SetCommonFieldForUpdate(e.rpl); }
                 if (e.rsa != null) { e.rsa.AssignedTo = e.userID; CommonTools.SetCommonFieldForUpdate(e.rsa); }
                 if (e.rsb != null) { e.rsb.AssignedTo = e.userID; CommonTools.SetCommonFieldForUpdate(e.rsb); }
                 if (e.rsf != null) { e.rsf.AssignedTo = e.userID; CommonTools.SetCommonFieldForUpdate(e.rsf); }
                 if (e.ra != null) { e.ra.AssignedTo = e.userID; CommonTools.SetCommonFieldForUpdate(e.ra); }
             });


            //insert email history record
            __misunitofwork.GetRepository<EmailRecord>().Insert(salesDocEmail.AsEnumerable().Select(e =>
            {
                var er = new EmailRecord
                {
                    ReceivedPost = e.Post,
                    Subject = e.Subject,
                    ReceivedUser = e.UserID,
                    Content = e.Message,
                    IsSent = "N",
                    IsDeleted = "N"
                };
                CommonTools.SetCommonFieldForCreate(er);
                return er;
            }).ToList()); ;


            __misunitofwork.Commit();
        }
    }
    #endregion
}
