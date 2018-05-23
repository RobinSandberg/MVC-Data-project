using MVC_Data_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Data_project.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            Person listofperson = new Person();
           
            return View(Person.DbPeople);
        }

        public ActionResult PersonList(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            return PartialView("_personList", person);
        }
        public ActionResult Create()
        {
            return PartialView("_Createbutton");
        }

        public ActionResult PartCreatePerson()
        { 
            return PartialView("_partCreate");
        }
        public ActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DbPeople.Add(person);
                return PartialView("_personList", person);
            }
            return new HttpStatusCodeResult(400);
        }

        public ActionResult EditPerson(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            return PartialView("_editPerson", person);
        }


        public ActionResult EditSave(Person person)
        {
            Person oldperson = Person.DbPeople.SingleOrDefault(i => i.Id == person.Id);

            if (oldperson == null)
            {
                return new HttpStatusCodeResult(400);
            }
            else
            {
                oldperson.Name = person.Name;
                oldperson.City = person.City;
                oldperson.PhoneNumber = person.PhoneNumber;
                return PartialView("_personList", oldperson);
            }

        }

        public ActionResult DetailPerson(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            return PartialView("_detailPerson", person);
        }

        public ActionResult RemovePerson(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Remove(person);
            return Content("");
        }

       
        public ActionResult SearchPeople(string searchString)
        {
            var people_search = from p in Person.DbPeople select p;
            
            if(!string.IsNullOrWhiteSpace(searchString))
            {
                people_search = people_search.Where(i => i.Name.ToLower().Contains(searchString) || i.City.ToLower().Contains(searchString));
            }
            
            return PartialView("_personListTest", people_search.ToList());
        }

        public ActionResult SortNameUp()
        {
            return PartialView("_personListTest", Person.DbPeople.OrderBy(p => p.Name).ToList());
        }

        public ActionResult SortNameDown()
        {
            return PartialView("_personListTest", Person.DbPeople.OrderByDescending(p => p.Name).ToList());
        }

        public ActionResult SortCityUp()
        {
            return PartialView("_personListTest", Person.DbPeople.OrderBy(p => p.City).ToList());
        }

        public ActionResult SortCityDown()
        {
            return PartialView("_personListTest", Person.DbPeople.OrderByDescending(p => p.City).ToList());
        }
    }
}