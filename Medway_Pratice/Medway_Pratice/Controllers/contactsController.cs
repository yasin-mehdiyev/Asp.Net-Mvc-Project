using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class contactsController : baseController
    {
        // GET: contacts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(string Name,string Email,string Subject,string Message)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Message))
            {
                return HttpNotFound();
            }

            var body = "<p>Name: {0} <br> Email: {1} <br> Subject: {2} <br> Message: {3} </p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(Email));  // replace with valid value 
            message.From = new MailAddress(Email);  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, Name, Email,Subject, Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "mway5526@gmail.com",  // replace with valid value
                    Password = "7J{3vsJHr?Z^_5qH"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                return RedirectToAction("index");
            }
        }
    }
}