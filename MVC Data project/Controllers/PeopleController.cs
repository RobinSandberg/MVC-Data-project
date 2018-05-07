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
        public ActionResult Index()
        {
            return View(Person.DbPeople);
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
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Remove(person);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Person person = Person.DbPeople.SingleOrDefault(i => i.Id == id);
            Person.DbPeople.Add(person);

            return RedirectToAction("Index");
        }

        
        public ActionResult Details()
        {
            return View(Person.DbPeople);
        }

        public ActionResult Hide()
        {
            return RedirectToAction("Index");
        }
    }
}