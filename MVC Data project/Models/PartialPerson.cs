using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Data_project.Models
{
    public class PartialPerson
    {

        public List<Person> persons;

        public PartialPerson(List<Person> persons)
        {
            this.persons = persons;
            
        }
       
    }
}