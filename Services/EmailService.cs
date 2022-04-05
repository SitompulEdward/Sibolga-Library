using Microsoft.Extensions.Options;
using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sibolga_Library.Services
{
    public class EmailService
    {
        private readonly IOptions<Email> _json;

        public EmailService(IOptions<Email> email)
        {
            _json = email;
        }

        public bool SendEmail(string tujuan, string judulEmail, string isiEmail)
        {
            try
            {
                Email e = new();

                e.NamaClient = _json.Value.NamaClient;
                e.Port = _json.Value.Port;
                e.EmailKita = _json.Value.EmailKita;
                e.Password = _json.Value.Password;

                MailMessage m = new();

                m.From = new MailAddress(e.EmailKita);
                m.Subject = judulEmail;
                m.Body = isiEmail;
                m.IsBodyHtml = true;
                m.To.Add(tujuan);

                SmtpClient s = new SmtpClient(e.NamaClient);

                s.Port = e.Port;
                s.Credentials = new System.Net.NetworkCredential(e.EmailKita, e.Password);
                s.EnableSsl = true;
                s.Send(m);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
