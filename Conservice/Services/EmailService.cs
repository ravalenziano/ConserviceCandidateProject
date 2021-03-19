using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration config)
        {
            _configuration = config;
        }

        public async void SendMail(string subject, string body, string recipients)
        {
           var section = _configuration.GetSection("Emails");

            using (var message = new MailMessage())
            {
                message.To.Add(recipients);

                message.Subject = subject;
                message.Body = body;
                message.From = new MailAddress(section["FromEmail"]);

                using (var smtpClient = new SmtpClient(section["SmtpClient"])
                {
                    Port = 587,
                    Credentials = new NetworkCredential(section["Username"], section["Password"]),
                    EnableSsl = true,
                })
                {
                  //  await smtpClient.SendMailAsync(message);
                }
            }
        }
    }
}
