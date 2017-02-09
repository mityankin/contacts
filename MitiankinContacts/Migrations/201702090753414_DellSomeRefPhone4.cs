namespace MitiankinContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DellSomeRefPhone4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Phones", "PresonRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "PresonRefId", c => c.Int(nullable: false));
        }
    }
}
