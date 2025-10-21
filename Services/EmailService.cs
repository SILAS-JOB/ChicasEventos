using ChicasEventos.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace ChicasEventos.Services
{
    public interface IEmailService
    {
        Task SendOrderEmailAsync(string toEmail, string subject, string htmlBody);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;

            if (emailSettings == null)
            {
                _logger.LogError("--- DIAGNÓSTICO: IOptions<EmailSettings> chegou NULO no construtor! ---");
            }
            else if (emailSettings.Value == null)
            {
                _logger.LogError("--- DIAGNÓSTICO: emailSettings.Value está NULO! A seção 'EmailSettings' não foi encontrada ou está mal formatada? ---");
            }
            else
            {
                _logger.LogInformation("--- DIAGNÓSTICO: emailSettings.Value foi carregado. Verificando propriedades... ---");
                // Logamos os valores INDIVIDUALMENTE para ter certeza absoluta
                _logger.LogInformation($"--- SenderEmail: '{emailSettings.Value.SenderEmail}' ---");
                _logger.LogInformation($"--- SmtpServer: '{emailSettings.Value.SmtpServer}' ---");
                _logger.LogInformation($"--- Port: '{emailSettings.Value.Port}' ---");
                _logger.LogInformation($"--- Username: '{emailSettings.Value.Username}' ---");
                // Não logue a senha em produção real, mas para depurar localmente pode ajudar
                // _logger.LogInformation($"--- Password: '{emailSettings.Value.Password}' ---"); 
            }
            _emailSettings = emailSettings?.Value ?? new EmailSettings();

        }

        public async Task SendOrderEmailAsync(string toEmail, string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlBody
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.StartTls);
                // await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}