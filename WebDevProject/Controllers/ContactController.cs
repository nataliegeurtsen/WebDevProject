using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;
using WebDevProject.Models;
using System.Dynamic;

namespace WebDevProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyDbContext _myDbContext;
        public ContactController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            //het person-object zal automatisch worden gevuld met de waarden uit het formulier
            //je kunt het person-object gebruiken om logica uit te voeren of de gegevens op te slaan in een database
            //maak de rescourcfe aan met de gegevens uit het model
            if (!ModelState.IsValid)
            {
                //het model is ongeldig, dus je kunt een foutmelding teruggeven of het formulier opnieuw renderen met foutmeldingen
                Console.WriteLine(ModelState);
                return BadRequest("Invalid data received");
            }
            //het model is geldig, dus je kunt logica uitvoeren of de gegevens opslaan in een database
            _myDbContext.Persons.Add(person);
            _myDbContext.SaveChanges();
            _ = SendContactMail(person.FormId, person.FirstName, person.LastName, person.Email, person.Subject, person.Message, person.PhoneNumber, person.Callback, person.CallbackAvailableMonday, person.CallbackAvailableTuesday, person.CallbackAvailableWednesday, person.CallbackAvailableThursday, person.CallbackAvailableFriday);
            _ = SendContactConfirmationMail(person.Subject, person.Message, person.Email, person.FirstName, person.LastName, person.PhoneNumber);
            
            Console.WriteLine("Succeeded");
            return RedirectToAction("Index");
        }

        [HttpPut]
        public IActionResult Update(int id, Person person)
        {
            //update de resource met het opgegeven ID met de gegevens uit het model
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //verwijder de resource met het opgegeven ID
            return NoContent();
        }

        static async Task SendContactConfirmationMail(string emailsubject, string message, string emailto, string firstname, string lastname, int tel)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("nataliegeurtsen@gmail.com", "Natalie Geurtsen");
            var subject = emailsubject;
            var fullname = firstname + " " + lastname;
            var to = new EmailAddress(emailto, fullname);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        static async Task SendContactMail(Guid formid, string firstname, string lastname, string emailto, string emailsubject, string message, int tel, bool callback, bool callbackmonday, bool callbacktuesday, bool callbackwednesday, bool callbackthursday, bool callbackfriday)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var fullname = firstname + " " + lastname;

            dynamic dynamicTemplateData = new ExpandoObject();
            dynamicTemplateData.formid = formid.ToString()[28..36];
            dynamicTemplateData.firstname = firstname;
            dynamicTemplateData.lastname = lastname;
            dynamicTemplateData.emailto = emailto;
            dynamicTemplateData.emailsubject = emailsubject;
            dynamicTemplateData.message = message;
            dynamicTemplateData.tel = tel;
            dynamicTemplateData.callback = callback;
            dynamicTemplateData.callbackmonday = callbackmonday;
            dynamicTemplateData.callbacktuesday = callbacktuesday;
            dynamicTemplateData.callbackwednesday = callbackwednesday;
            dynamicTemplateData.callbackthursday = callbackthursday;
            dynamicTemplateData.callbackfriday = callbackfriday;

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("nataliegeurtsen@gmail.com", "Natalie Geurtsen"),
                Subject = emailsubject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.SetTemplateId("d-ccd31a3163564adcaa3da4a76d159099");
            msg.SetTemplateData(dynamicTemplateData);
            msg.AddTo(new EmailAddress(emailto, fullname));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to send contactmail to nataliegeurtsen@gmail.com");
                return;
            }
            Console.WriteLine("Succesfully sent contactmail to nataliegeurtsen@gmail.com");
            //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("nataliegeurtsen@gmail.com", "Natalie Geurtsen");
            //var subject = emailsubject;
            //var fullname = firstname + " " + lastname;
            //var to = new EmailAddress(emailto, fullname);
            //var plainTextContent = message;
            //var htmlContent = message;
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);
        }
    }
}
