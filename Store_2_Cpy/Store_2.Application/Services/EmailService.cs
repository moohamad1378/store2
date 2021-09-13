using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Services
{
    public class EmailService
    {
        public Task Execute(string email,string Body,string Subject)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";

            client.EnableSsl = true;
            client.Timeout = 1000000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("moohamad.norway@gmail.com", "m09167689037m");
            MailMessage message = new MailMessage("moohamad.norway@gmail.com", email, Subject, Body);
            message.IsBodyHtml = true;
            //for sending persain email
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            
            client.Send(message);
            return Task.CompletedTask;
        }
    }
}
