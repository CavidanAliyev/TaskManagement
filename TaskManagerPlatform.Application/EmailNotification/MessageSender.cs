using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.EmailNotification;

namespace TaskManagerPlatform.Application.MailSender
{
    public class MessageSender : IEmailSender
    {
        // from which the email will go
        private readonly string userName = ""; 
        private readonly string fromEmail = ""; 
        private readonly string password = "";

        private readonly IConfiguration _configuration;

        public MessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(subject, fromEmail));
            mimeMessage.To.Add(new MailboxAddress(subject, email));
            mimeMessage.Subject = subject; 
            mimeMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(userName, password);
                await client.SendAsync(mimeMessage);
                Console.WriteLine("The mail has been sent successfully !!");
                Console.ReadLine();
                await client.DisconnectAsync(true);
            }
        }
    }
}
