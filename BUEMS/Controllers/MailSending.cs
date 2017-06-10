using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using BUEMS.Models;

namespace BUEMS.Controllers
{
    public static class MailSending
    {
        public static string SendMailWithAttachment(string receiverMail)
        {
            var memoryStream=new MemoryStream(System.IO.File.ReadAllBytes("F:\\VisualStdioProjects\\BUEMS\\BUEMS\\Controllers\\Testpdf.pdf"));
            memoryStream.Position = 0;

            var mm = new MailMessage("tz2201@gmail.com", receiverMail)
            {
                Subject = "চলতি মাসের বেতন",
                Body = "আপনার চলতি মাসের বেতন আপনার ব্যাংক এক্যাউন্টে যোগ করা হয়েছে। বেতন রসিদ মেইলের সাথে সংযুক্ত করা হল। ",
                IsBodyHtml = true
            };
            mm.Attachments.Add(new Attachment(memoryStream, "Testpdf.pdf"));
            var smtp = CreateSmtpClient();
            smtp.Send(mm);

            return "Success";

        }

        public static MailMessage MailModelToMailMessage(MailModel mailModel)
        {
            var mailMessage= new MailMessage("tz2201@gmail.com",mailModel.To)
            {
                Subject = mailModel.Subject,
                Body = mailModel.Body,
                IsBodyHtml = true,
            };

            return mailMessage;
        }

        public static SmtpClient CreateSmtpClient()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential("tz2201@gmail.com", "153045609zA")
            };
            smtp.EnableSsl = true;
            return smtp;
        }
        public static string SendMail(MailModel mailS)
        {
            var mail = new MailMessage();
            mail.To.Add("bsse0504@iit.du.ac.bd");
            mail.From = new MailAddress(mailS.From);
            mail.Subject = mailS.Subject;
            string body = mailS.Body;
            mail.Body = body;
            mail.IsBodyHtml = true;
            var smtp = CreateSmtpClient();
            smtp.Send(mail);

            return "Success";
        }

    }
}