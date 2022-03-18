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
                MailMessage message = new MailMessage("necafcsmtp@gmail.com", emailObject.EmailAddress);
                message.Subject = "Sales Document notice";
                message.Body = emailObject.Message;
                __smtpClient.Send(message);
            }
        }
    }
}
