using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models.GoogleJson
{
    public class AddressComponent
    {
        public string Long_name { get; set; }
        public string Short_name { get; set; }
        public List<string> Types { get; set; }
    }
}