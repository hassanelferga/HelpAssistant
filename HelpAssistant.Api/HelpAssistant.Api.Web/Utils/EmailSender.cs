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
                SmtpClient client = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("mibrahim_elferga@hotmail.com");
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = htmlMsg;
                mail.Body = htmlBody;
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("mibrahim_elferga@hotmail.com", "MOHAMEDibrahim");
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