﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models
{
    public class ContactModelView
    {
        public ContactModelView()
        {
            Numbers = new List<NumberModelView>();
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
            this.Deleted = false;
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Deleted { get; set; }
        public List<NumberModelView> Numbers { get; set; }
    }
}