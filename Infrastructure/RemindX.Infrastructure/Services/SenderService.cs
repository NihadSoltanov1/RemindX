using RemindX.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RemindX.Infrastructure.Services
{
    public class SenderService : ISenderService
    {
        public void RemindByEmail(string to, string content)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("nihadsoltanov@hotmail.com");
            mail.To.Add(to);
            mail.Subject = content;
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = "<b>Write</b> some HTML code here";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("nihadsoltanov@hotmail.com", "webbb222444-444222");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        public async  Task RemingByTelegram(string to, string content)
        {
           
                var botClient = new TelegramBotClient("6231901561:AAHae7i-RGGWNTJGR2xdSV4VZPn__zUKY30");
                await botClient.GetUpdatesAsync();

                await botClient.SendTextMessageAsync(int.Parse(to), content);
            
        }
    }
}
