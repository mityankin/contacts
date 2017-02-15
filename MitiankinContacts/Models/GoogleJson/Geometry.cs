using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models.GoogleJson
{
    public class Geometry
    {
        public Location Location { get; set; }
        public string Location_type { get; set; }
        public Viewport Viewport { get; set; }
    }
}