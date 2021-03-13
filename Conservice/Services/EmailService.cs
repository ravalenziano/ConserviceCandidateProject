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
        public void SendMail(string subject, string body, string recipients)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ravalenziano", "S4msung226bw!"),
                EnableSsl = true,
            };

            smtpClient.Send("ravalenziano@gmail.com", recipients, subject, body);
        }
    }
}
