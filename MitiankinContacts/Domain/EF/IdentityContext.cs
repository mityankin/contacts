namespace MitiankinContacts.Domain.EF
{
    using Entity.Security;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;


        public class IdentityContext : IdentityDbContext<User>
        {
            public IdentityContext() : base("name=DataContext")
            {
            }

        }
    }