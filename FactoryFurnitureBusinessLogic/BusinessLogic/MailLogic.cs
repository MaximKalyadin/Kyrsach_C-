using FactoryFurnitureBusinessLogic.BindingModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    public class MailLogic
    {
        public void SendMassege(ReportBindingModel model, string Email, string subject, string body)
        {
            MailAddress from = new MailAddress("kalyadin.maxim@gmail.com");
            MailAddress to = new MailAddress(Email);
            MailMessage mes = new MailMessage(from, to);
            mes.Subject = subject;
            mes.Body = body;
            mes.Attachments.Add(new Attachment(model.FileName));
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("kalyadin.maxim@gmail.com", "42MAKS01253");
            client.EnableSsl = true;
            client.Send(mes);

        }
    }
}
