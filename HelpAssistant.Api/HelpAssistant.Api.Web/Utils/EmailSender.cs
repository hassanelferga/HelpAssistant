using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HelpAssistant.Api.Web.Utils
{
    public static  class EmailSender
    {
        public static bool SendEmail(string emailTo, string subject, string htmlMsg)
        {
            bool isSent = false;
            try
            {
                SmtpClient client = new SmtpClient(AppSettings.SmtpServer);
                var mail = new MailMessage();
                mail.From = new MailAddress(AppSettings.FromEmail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = htmlMsg;
                mail.Body = htmlBody;
                client.Port = AppSettings.Port;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(AppSettings.FromEmail, AppSettings.FromEmailPassword);
                client.EnableSsl = true;
                client.Send(mail);
                isSent = true;
            }
            catch(Exception ex)
            {
                
            }
            return isSent;
        }
    }
}