using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Domain.Entity.Security
{
    public class User : IdentityUser
    {
        public string Country { get; set; }

        public int Age { get; set; }
    }
}
