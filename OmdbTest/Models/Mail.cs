using System.Net;
using System.Net.Mail;

namespace OmdbTest.Models
{
    public class Mail
    {
        public string To { get; set; } 
        public string FromEmail { get; set; } = "Nabi.Huseynov@emanat.az";       
        public string Message { get; set; }
        public string Fullname { get; set; }

      






        //SmtpClient smtpClient = new SmtpClient()
        //{
        //    Host = "smtp.gmail.com",
        //    Port = 587,
        //    EnableSsl = true,
        //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    UseDefaultCredentials = false,
        //    Credentials = new NetworkCredential
        //    {
        //        UserName = "asgarliaytac@gmail.com",
        //        Password = "munc*****"
        //    }
        //};

        //MailAddress Fromemail = new MailAddress("asgarliaytac@gmail.com", "Asgarova Aytac");
        //MailAddress Toemail = new MailAddress("qaradervis13@gmail.com", "Somebody");
       

        //public Mail(MailAddress fromMail, MailMessage message)
        //{
        //    FromEmail = fromMail.Address;
        //    ToEmail = "asgarliaytac@gmail.com";
        //}
    };
}
