using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Try.BL.Helper
{
    public static class MailHelper
    {
        public static string sendMail(string Title , string Message)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");


                smtp.Send("as8338873@gmail.com", "elgendya160@gmail.com", Title, Message);

                return "Mail Sent Successfully";

                //MailMessage m = new MailMessage();

                //m.From = "";
                //m.To = "";
                //m.Subject = "";
                //m.Body = "";
                //m.CC = "";
                //m.Attachments = "";

            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }
    }
}
