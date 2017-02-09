namespace MitiankinContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefPhone3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "phone_Id", "dbo.Phones");
            DropIndex("dbo.Phones", new[] { "phone_Id" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            CreateIndex("dbo.Phones", "person_Id");
            DropColumn("dbo.Phones", "phone_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "phone_Id", c => c.Int());
            DropIndex("dbo.Phones", new[] { "person_Id" });
            CreateIndex("dbo.Phones", "Person_Id");
            CreateIndex("dbo.Phones", "phone_Id");
            AddForeignKey("dbo.Phones", "phone_Id", "dbo.Phones", "Id");
        }
    }
}
