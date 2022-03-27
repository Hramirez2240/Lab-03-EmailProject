using EmailBossProject.Core.Model;
using EmailBossProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        public readonly EmailSettings _settings;

        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task<bool> SendEmail(string message, List<string> to)
        {
            var authentication = new NetworkCredential(_settings.Email, _settings.Password);

            var client = new SmtpClient(_settings.Host)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = authentication,
                Port = _settings.Port,
                EnableSsl = true
            };

            var mailAddress = new MailAddress(_settings.Email, _settings.DisplayName);

            var mailMessage = new MailMessage()
            {
                Subject = "Boss Change!!",
                SubjectEncoding = Encoding.UTF8,
                From = mailAddress,

                Body = message,
                BodyEncoding = Encoding.UTF8,
            };

            foreach (var destinatary in to)
            {
                mailMessage.To.Add(new MailAddress(destinatary));
            }

            client.Send(mailMessage);

            return true;
        }

        public static async void CreateMessage(string oldbossmail, string newbossmail, string employeename, string newbossname)
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
