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

        public void SendMail(string subject, string body, string recipients)
        {
           var section = _configuration.GetSection("Emails");
            var smtpClient = new SmtpClient(section["SmtpClient"])
            {
                Port = 587,
                Credentials = new NetworkCredential(section["Username"], section["Password"]),
                EnableSsl = true,
            };

            smtpClient.Send(section["FromEmail"], recipients, subject, body);
        }
    }
}
