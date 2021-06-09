using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Paideia.Application.Interfaces;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class SendEmailAppService : ISendEmailAppService
    {        
        public void SendEmail(LoginViewModel loginVM, string securityStamp )
        {            
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Paideia", "sistema.paideia@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("Davi", loginVM.Email));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = $"Para redefinir acesse o link https://localhost:44379/Login/Reset?email={loginVM.Email}&token={securityStamp}"               
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtpClient.Authenticate("sistema.paideia@gmail.com", "Paideia2021");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
