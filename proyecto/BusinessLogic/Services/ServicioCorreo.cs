using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.Json;

namespace LayeredApp.Business.Services
{
    public class EmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;

        public EmailService()
        {
            
            _host = Environment.GetEnvironmentVariable("SMTP_HOST") ?? string.Empty;
            _user = Environment.GetEnvironmentVariable("SMTP_USER") ?? string.Empty;
            _pass = Environment.GetEnvironmentVariable("SMTP_PASS") ?? string.Empty;
            int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out _port);

            
            if (string.IsNullOrWhiteSpace(_host) || string.IsNullOrWhiteSpace(_user) || string.IsNullOrWhiteSpace(_pass) || _port == 0)
            {
                try
                {
                    var baseDir = AppContext.BaseDirectory;
                    var candidate = Path.Combine(baseDir, "appsettings.json");
                    if (!File.Exists(candidate))
                    {
                        var parent = Path.GetDirectoryName(baseDir) ?? baseDir;
                        candidate = Path.Combine(parent, "appsettings.json");
                    }
                    if (File.Exists(candidate))
                    {
                        var js = File.ReadAllText(candidate);
                        using var doc = JsonDocument.Parse(js);
                        if (doc.RootElement.TryGetProperty("Smtp", out var smtp))
                        {
                            if (string.IsNullOrWhiteSpace(_host) && smtp.TryGetProperty("Host", out var h)) _host = h.GetString() ?? _host;
                            if (_port == 0 && smtp.TryGetProperty("Port", out var p) && p.TryGetInt32(out var pi)) _port = pi;
                            if (string.IsNullOrWhiteSpace(_user) && smtp.TryGetProperty("User", out var u)) _user = u.GetString() ?? _user;
                            if (string.IsNullOrWhiteSpace(_pass) && smtp.TryGetProperty("Pass", out var pw)) _pass = pw.GetString() ?? _pass;
                            
                        }
                    }
                }
                catch {  }
            }
            
            if (_port == 0) _port = 587;
        }

        public void Send(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(_host) || string.IsNullOrWhiteSpace(_user) || string.IsNullOrWhiteSpace(_pass))
                throw new InvalidOperationException("SMTP settings not configured. Set SMTP_HOST/SMTP_PORT/SMTP_USER/SMTP_PASS or add Smtp section to appsettings.json.");

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

