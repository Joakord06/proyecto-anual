using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace LayeredApp.Business.Services
{
    public class EmailService
    {
        private readonly string _host = "smtp.example.com";
        private readonly int _port = 587;
        private readonly string _user = "tu@correo.com";
        private readonly string _pass = "tu_pass_o_token";

        public void Send(string to, string subject, string body)
        {
            using var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_user, _pass),
                EnableSsl = true
            };
            var msg = new MailMessage(_user, to, subject, body) { IsBodyHtml = false };
            client.Send(msg);
        }
    }
}
