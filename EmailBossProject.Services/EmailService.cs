using EmailBossProject.Core.Model;
using EmailBossProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Services
{
    public class EmailService
    {
        public async Task<bool> SendEmail(string message, List<string> to)
        {
            var authentication = new NetworkCredential("hramrez3@gmail.com", "ElGoldoZozoYLolaJiji2240");

            var client = new SmtpClient("smtp.gmail.com")
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = authentication,
                Port = 587,
                EnableSsl = true
            };

            var mailAddress = new MailAddress("hramrez3@gmail.com", "Hector Ramirez");

            var mailMessage = new MailMessage()
            {
                Subject = "Boss Change!!",
                SubjectEncoding = System.Text.Encoding.UTF8,
                From = mailAddress,

                Body = message,
                BodyEncoding = System.Text.Encoding.UTF8,
            };

            foreach (var destinatary in to)
            {
                mailMessage.To.Add(new MailAddress(destinatary));
            }

            client.Send(mailMessage);

            return true;
        }

        public async static void CreateMessage(string oldbossmail, string newbossmail, string employeename, string newbossname)
        {
            var email = new EmailService();
            string mensaje = $"Hello to everyone, we want to inform that {newbossname} will be the next boss of {employeename}, best regards";

            List<string> toAddress = new()
            {
                oldbossmail,
                newbossmail
            };

            await email.SendEmail(mensaje, toAddress);
        }
    }
}
