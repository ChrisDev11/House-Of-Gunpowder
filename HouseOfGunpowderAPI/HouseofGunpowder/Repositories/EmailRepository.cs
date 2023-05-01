using HouseofGunpowder.Repositories.Interfaces;
using System.Net;
using System.Net.Mail;

namespace HouseofGunpowder.Repositories {
    public class EmailRepository : IEmail {

        private readonly IConfiguration _configuration;

        public EmailRepository(IConfiguration configuration) {
            _configuration = configuration;
        }


        public bool Send(string email, string subject, string message) {
            try {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string username = _configuration.GetValue<string>("SMTP:Username");
                string key = _configuration.GetValue<string>("SMTP:Key");
                int port = _configuration.GetValue<int>("SMTP:Port");

                MailMessage mail = new MailMessage() {
                    From = new MailAddress(username, name)
                };

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port)) {
                    smtp.Credentials = new NetworkCredential(username, key);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    return true;
                }
            } catch (System.Exception ex) {
                return false;
            }
        }
    }
}
