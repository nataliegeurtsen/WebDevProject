using Microsoft.AspNetCore.Mvc;
using WebDevProject.Models;

namespace WebDevProject.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            //het person-object zal automatisch worden gevuld met de waarden uithet formulier
            //je kunt het person-object gebruiken om logica uit te voeren of de gegevens op te slaan in een database
            //maak de rescourcfe aan met de gegevens uit het model
            if (ModelState.IsValid)
            {
                //het model is geldig, dus je kunt logica uitvoeren of de gegevens opslaan in een database
            }
            else
            {
                //het model is ongeldig, dus je kunt een foutmelding teruggeven of het formulier opnieuw renderen met foutmeldingen

            }

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
    }
}
