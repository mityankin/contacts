namespace MitiankinContacts.Migrations
{
    using Domain.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MitiankinContacts.Domain.EF.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MitiankinContacts.Domain.EF.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.ContactPhoneType.AddOrUpdate(p => p.TypeName,
                new PhoneType { TypeName = "Mobile" }, new PhoneType { TypeName = "Work" }, new PhoneType { TypeName = "Home" }
            );


            
        }
    }
}
