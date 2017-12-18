using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String ReceiverEmail, String Subject, String Message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Sendermail = new MailAddress("zeeshantanooli@gmail.com", "Testing Email");
                    var Receivermail = new MailAddress(ReceiverEmail, "Receiver");
                    var Password = "03461496799";
                    var sub = Subject;
                    var body = Message;
                    var smtp = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod=SmtpDeliveryMethod.Network,
                        UseDefaultCredentials=false,
                        Credentials=new NetworkCredential(Sendermail.Address,Password)
                    };
                    using (var mess = new MailMessage(Sendermail, Receivermail)
                    {
                        Subject = sub,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);

                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Sending Fail";

            }
            return View();

        }
    }
}