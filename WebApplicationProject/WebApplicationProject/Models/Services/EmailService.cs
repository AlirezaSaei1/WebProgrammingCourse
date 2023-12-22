using System.Net;
using System.Net.Mail;
using WebApplicationProject.Services;

namespace WebApplicationProject.Models.Services;

public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendLoginEmail(string username)
        {
            var emailBody = $"Hello {username},\n\nYou have successfully logged in to our website.";

            SendEmail(username, "Login Successful", emailBody);
        }

        public void SendSignupEmail(string email)
        {
            var emailBody = $"Thank you for signing up! Your account has been created with the email: {email}.";

            SendEmail(email, "Signup Successful", emailBody);
        }

        private void SendEmail(string recipient, string subject, string body)
        {
            var senderEmail = _configuration["Email:SenderEmail"];
            var senderPassword = _configuration["Email:SenderPassword"];
            var smtpServer = _configuration["Email:SmtpServer"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);

            using var client = new SmtpClient(smtpServer, smtpPort);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);
            client.EnableSsl = true;

            var message = new MailMessage(senderEmail, recipient, subject, body);
            client.Send(message);
        }
    }