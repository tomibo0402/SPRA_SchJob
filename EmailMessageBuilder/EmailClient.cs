using SPRA_SchJob.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SPRA_SchJob.EmailMessageBuilder
{
    public class EmailClient
    {
        private readonly SmtpClient __smtpClient;
        public EmailClient(SmtpClient smtpClient)
        {
            __smtpClient = smtpClient;
        }
        public string BuildMessage(string messageTemplate, List<object> value)
        {
            return string.Format(messageTemplate, value.Select(e => e.ToString()).ToArray());
        }

        public async Task SendMessage(List<DocEmailModel> emailMessage)
        {
            foreach (var emailObject in emailMessage)
            {
                var fromEmail = __smtpClient.Credentials.GetCredential(__smtpClient.Host, __smtpClient.Port, "").UserName;
                MailMessage message = new MailMessage(fromEmail, emailObject.EmailAddress);
                message.Subject = emailObject.Subject;
                message.IsBodyHtml = true;
                message.Body = emailObject.Message;
                __smtpClient.Send(message);
            }
        }
    }
}
