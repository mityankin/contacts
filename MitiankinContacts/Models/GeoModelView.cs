using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models
{
    public class GeoModelView
    {
        public GeoModelView()
        {
            Lat = 0;
            Lng = 0;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}