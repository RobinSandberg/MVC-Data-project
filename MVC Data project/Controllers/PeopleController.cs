using MVC_Data_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Data_project.Controllers
{
    public class PeopleController : Controller
    {
       
        
        // GET: People
        public ActionResult Index(string sortOrder ,string searchString)
        {
            Person listofperson = new Person();
            
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            ViewBag.CitySortParm = string.IsNullOrEmpty(sortOrder) ? "city_sort" : "";

            var people_search = from p in Person.DbPeople select p;

            if (!String.IsNullOrEmpty(searchString))
            {
               people_search = people_search.Where(i => i.Name.ToLower().Contains(searchString) || i.City.ToLower().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_sort":
                    people_search = people_search.OrderBy(p => p.Name);
                    break;
                case "city_sort":
                    people_search = people_search.OrderBy(p => p.City);
                    break;
                
            }
            
            return View(people_search);
        }

        public ActionResult PartIndex()
        {
            Person listofperson = new Person();
            PartialPerson part = new PartialPerson(Person.DbPeople);

            //ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            //ViewBag.CitySortParm = string.IsNullOrEmpty(sortOrder) ? "city_sort" : "";

            //var people_search = from p in Person.DbPeople select p;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    people_search = people_search.Where(i => i.Name.ToLower().Contains(searchString) || i.City.ToLower().Contains(searchString));
            //}

            //switch (sortOrder)
            //{
            //    case "name_sort":
            //        people_search = people_search.OrderBy(p => p.Name);
            //        break;
            //    case "city_sort":
            //        people_search = people_search.OrderBy(p => p.City);
            //        break;

            //}


            return View(part);
        }

        public ActionResult PartPerson(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);

            return PartialView("_PartPerson", person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DbPeople.Add(person);
                return RedirectToAction("PartIndex");
            }
            else
            {
                return View(person);
            }
        }

       
        public ActionResult Delete(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Remove(person);
            
            return RedirectToAction("PartIndex");
        }

       [HttpGet]
        public ActionResult Edit(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Remove(person);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DbPeople.Add(person);
                return RedirectToAction("PartIndex");
            }
            else
            {
                return View(person);
            }
           
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            return View(person);
        }

        public ActionResult Hide(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            return RedirectToAction("PartIndex");
        }
    }
}