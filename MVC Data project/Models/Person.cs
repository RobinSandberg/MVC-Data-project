using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Data_project.Models
{
    public class Person
    {
        static int idCount = 0;
        public static List<Person> DbPeople = new List<Person>();

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public Person()
        {
            Id = idCount++;
        }
    }
}