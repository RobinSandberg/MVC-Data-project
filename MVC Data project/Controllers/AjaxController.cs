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

        public ActionResult RemovePerson(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Remove(person);
            return Content("");
        }

        public ActionResult SortList(string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            ViewBag.CitySortParm = string.IsNullOrEmpty(sortOrder) ? "city_sort" : "";

            var PeopleSort = from p in Person.DbPeople select p;

            switch (sortOrder)
            {
                case "name_sort":
                    PeopleSort = PeopleSort.OrderBy(p => p.Name);
                    break;
                case "city_sort":
                    PeopleSort = PeopleSort.OrderBy(p => p.City);
                    break;

            }

            return PartialView("_personList", PeopleSort);
        }

        public ActionResult SearchPeople(string searchString)
        {
            
            var result = Person.DbPeople
                .Where(p =>
                    p.Name.ToLower().Contains(searchString) ||
                    p.City.ToLower().Contains(searchString)
                );
            return PartialView("_personList", result);
        }
    }
}