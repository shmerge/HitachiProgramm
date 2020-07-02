using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HitachiProgramm
{
    class MailService
    {
        private string senderUserName;
        private string password;
        private string receiverEmailAddress;
        private File fileVar;

        public MailService(string senderAddress, string pass, string receiverAddress)
        {
            fileVar = new File();
            this.senderUserName = senderAddress;
            this.password = pass;
            this.receiverEmailAddress = receiverAddress;
        }

        public void sendEmail(string message)
        {
            try
            {
                using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
                {
                    NetworkCredential login = new NetworkCredential(senderUserName, password);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = login;
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    msg.From = new MailAddress(senderUserName + "@gmail.com", "Human", Encoding.UTF8);
                    msg.To.Add(new MailAddress(receiverEmailAddress));
                    msg.Subject = message;
                    msg.Body = message;
                    msg.BodyEncoding = Encoding.Unicode;
                    msg.IsBodyHtml = true;
                    string attFile = fileVar.getFileName();
                    msg.Attachments.Add(new Attachment(@attFile));
                    msg.Priority = MailPriority.Normal;

                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The message is not sent.");
            }
        }
    }
}
