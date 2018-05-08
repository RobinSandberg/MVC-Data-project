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

        public string Details { get; set; }

        public Person()
        {
            Id = idCount++;
        }

        public void PersonList()
        {
            if (Id == 0)
            {
                DbPeople.Add(new Person() { Name = "Robin Sandberg", PhoneNumber = "3020-32623", City = "Växjö", Details = "A 35 year old man that studies IT." });
                DbPeople.Add(new Person() { Name = "Rick Mortenson", PhoneNumber = "0112-83271", City = "Stockholm", Details = "Some random made up person." });
                DbPeople.Add(new Person() { Name = "Eva Mortenson", PhoneNumber = "0112-83271", City = "Stockholm", Details = "Rick Mortenson made up wife." });
                DbPeople.Add(new Person() { Name = "Bertil Svensson", PhoneNumber = "2109-33212", City = "Göteborg", Details = "Another made up person." });
                DbPeople.Add(new Person() { Name = "Sven Turesson", PhoneNumber = "1009-21593", City = "Malmö", Details = "Making up people as I go." });
            }
        }
    }
}