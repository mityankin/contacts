using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Domain.Entity
{
    public class Phone
    {
        public int Id { get; set; }       
        public virtual PhoneType Type { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Person person { get; set; }
    }
}