using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Domain.Entity
{
    public class PhoneType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}