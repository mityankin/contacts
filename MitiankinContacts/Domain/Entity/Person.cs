using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Domain.Entity
{
    public class Person
    {
        public Person()
        {
            PhoneNumbers = new List<Phone>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Phone> PhoneNumbers { get; set; }
    }
}