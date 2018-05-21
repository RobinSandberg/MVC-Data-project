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
            Session["TestName"] = "name_sort";
            Session["TestCity"] = "city_sort";
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
            
            return PartialView("_searchPerson", people_search.ToList());
        }
        
        public ActionResult SortPeople(string sortOrder)
        {

            Session["TestName"] = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            Session["TestCity"] = string.IsNullOrEmpty(sortOrder) ? "city_sort" : "";

            var people_sort = from p in Person.DbPeople select p;

            switch (sortOrder)
            {
                case "name_sort":
                    people_sort = people_sort.OrderBy(p => p.Name);
                    break;
                case "city_sort":
                    people_sort = people_sort.OrderBy(p => p.City);
                    break;
                default:
                    people_sort = people_sort.OrderByDescending(p => p.Name);
                    break;

            }
            
            return PartialView("_sortPeople", people_sort.ToList());
        }
    }
}