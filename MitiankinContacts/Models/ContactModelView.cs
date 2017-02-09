using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models
{
    public class ContactModelView
    {
        public ContactModelView()
        {

        }

        public ContactModelView(int personId, string firstName, string lastName, string address, List<NumberModelView> numbers)
        {
            this.PersonId = personId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            if (numbers == null)
            {
                numbers = new List<NumberModelView>();
            }
            this.Numbers = numbers;
        }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<NumberModelView> Numbers { get; set; }
    }
}