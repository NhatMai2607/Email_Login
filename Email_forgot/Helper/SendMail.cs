using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace Email_forgot.Helper
{
    public class SendMail
    {
        public static bool SendEmail(string to, string subject, string body,string attachFile, ConstantHelper constantHelper)
        {
            try
            {
                MailMessage msg = new MailMessage(constantHelper.emailSender, to, subject, body);
                using (var client = new SmtpClient(constantHelper.HostEmail,constantHelper.portEmail))
                {
                    client.EnableSsl = true;

                    if(!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        msg.Attachments.Add(attachment);
                    }



                    NetworkCredential credential = new NetworkCredential(constantHelper.emailSender, constantHelper.passwordSender);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;
                    client.Send(msg);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        internal static void SendEmail(string email, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}