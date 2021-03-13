using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public interface IEmailService
    {
        public void SendMail(string subject, string body, string recipients);
    }
}
