using Microsoft.AspNetCore.Mvc;
using SignalFoodWebUI.Dtos.MailDtos;

using MimeKit;
using MailKit.Net.Smtp;

namespace SignalFoodWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            // Kimden Gönderildi
            MimeMessage mimeMessage = new MimeMessage();        // title - mail
            MailboxAddress mailboxAddress = new MailboxAddress("SignalFood Rezervasyon", "atakanturgut@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            // Kime Gönderileceği
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            // Konu
            mimeMessage.Subject = createMailDto.Subject;

            // Mail İçeriği
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);   // key - port - ssl
            client.Authenticate("atakanturgut@gmail.com", "rkrp dixq fysg pcma");      // mail - key

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Statistic");
        }

    }
}
