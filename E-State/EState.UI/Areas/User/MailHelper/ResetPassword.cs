using System.Net.Mail;

namespace EState.UI.Areas.User.MailHelper
{
    public class ResetPassword
    {
        public static void PasswordSendMail(string link)
        {
            MailMessage message = new MailMessage();

            SmtpClient smtpClient = new SmtpClient();

            message.From = new MailAddress("system@mail.com");

            message.To.Add("benimmailadresim");

            message.Subject = "Şifre güncelleme talebi";

            message.Body = "<h2>Şifrenizi yenilemek için linke tıklayınız </h2> <hr>";
            message.Body += $"<a href='{link}'> Şifre yenileme bağlantısı";

            message.IsBodyHtml = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("benimmailadresim", "xmjxxzisaemudzcm");
            smtpClient.Send(message);
        }
    }
}
