using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using albinajax.Models;

namespace albinajax.Controllers
{
    public class DefaultController : Controller
    {
        public DefaultController()
        {
            
        }
        // GET: Default
        public ActionResult Index()
        {
            //Lite test-data
            List<Person> defaultPeopleList = new List<Person>();
            defaultPeopleList.Add(new Person { PersonId = 1, FirstName = "Krille", LastName = "Krillesson", Email = "KrilleKrillesson@gmail.com" });
            defaultPeopleList.Add(new Person { PersonId = 2, FirstName = "Dungeon", LastName = "Master", Email = "DMpartyboy69@deepdark.com" });
            defaultPeopleList.Add(new Person { PersonId = 3, FirstName = "Greger", LastName = "Hawkwind", Email = "Greger@nilecity.com" });

            //Använder Session istället för databas
            Session["defaultPeopleList"] = defaultPeopleList;

            Person person = new Person();
            return View(person);
        }

        [HttpPost]
        public PartialViewResult PostUser(Person person)
        {
            //Hämtar in vår "databas"
            List<Person> defaultPeopleList = Session["defaultPeopleList"] as List<Person>;
            person.PersonId = defaultPeopleList.Count + 1;

            //Lägg till nya personen i "databasen"
            defaultPeopleList.Add(person);
            //Spara databasen
            Session["defaultPeopleList"] = defaultPeopleList;
            //Returnerar en partialview där vi ersätter allt i vår UpdateTargetId div i vyn.
            return PartialView("_PeopleListPartialView", defaultPeopleList);
        }
    }
}