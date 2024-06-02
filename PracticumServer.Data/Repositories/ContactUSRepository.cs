using Microsoft.Extensions.Configuration;
using PracticumServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PracticumServer.Data.Repositories
{
    public class ContactUSRepository : IContactUSRepository
    {
        private readonly IConfiguration _config;

        public ContactUSRepository(IConfiguration config)
        {
            _config = config;
        }

        public string GetEmailFrom()
        {
            return _config.GetValue<string>("EmailDetails:EmailFrom");
        }

        public void SendEmail(string To, string Subject, string Body)
        {
            try
            {
                var emailFrom = _config.GetValue<string>("EmailDetails:EmailFrom");
                var smtp = _config.GetValue<string>("EmailDetails:SMTP");
                var smtpPort = _config.GetValue<int>("EmailDetails:SMTPPort");
                var userName = _config.GetValue<string>("EmailDetails:UserName");
                var emailPassword = _config.GetValue<string>("EmailDetails:EmailPassword");
                var useDefaultCredentials = _config.GetValue<bool>("EmailDetails:UseDefaultCredentials");
                var enableSsl = _config.GetValue<bool>("EmailDetails:EnableSsl");
                System.Net.Mail.MailAddress mailAddress= new MailAddress("r0556721978@gmail.com",displayName:"CAREER PEAK");

                using (var client = new SmtpClient(smtp, smtpPort))
                {
                    client.UseDefaultCredentials = useDefaultCredentials;
                    client.EnableSsl = enableSsl;
                    client.Credentials = new NetworkCredential(userName, emailPassword);

                    var mailMessage = new MailMessage
                    {
                        From = mailAddress,//emailFrom,
                        Subject = Subject,
                        Body = Body,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(To);

                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}