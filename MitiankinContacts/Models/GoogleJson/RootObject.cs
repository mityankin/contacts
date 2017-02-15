using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models.GoogleJson
{
    public class RootObject
    {
        public List<Result> Results { get; set; }
        public string Status { get; set; }
    }
}