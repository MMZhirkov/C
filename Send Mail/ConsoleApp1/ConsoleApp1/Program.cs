using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace NetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SendEmailAsync().GetAwaiter();
            Console.Read();
        }

        private static async Task SendEmailAsync()
        {

            MailAddress from = new MailAddress("zhirkovmichael@gmail.com", "Michael Zhirkov");
            MailAddress to = new MailAddress("mmzhirkov@yandex.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест работы smtp-клиента";
            m.Attachments.Add(new Attachment("E://test.txt"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("@gmail.com", "Pas");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            Console.WriteLine("Письмо отправлено");
            Console.ReadKey();
        }
    }
}