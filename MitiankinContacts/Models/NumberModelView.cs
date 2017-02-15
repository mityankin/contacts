using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models
{
    public class NumberModelView
    {

        public NumberModelView()
        {

        }

        public NumberModelView(int IdInDatabase, string phone, int IdType, string type)
        {
            this.Phone = phone;
            this.Type = type;
            this.IdInDatabase = IdInDatabase;
            this.IdType = IdType;
            this.Deleted = false;
        }
        public int IdInDatabase { get; set; }
        public string Phone { get; set; }
        public int IdType { get; set; }
        public string Type { get; set; }
        public bool Deleted { get; set; }

    }
}