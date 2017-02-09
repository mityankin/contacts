namespace MitiankinContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefPhone2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "phone_Id", c => c.Int());
            CreateIndex("dbo.Phones", "phone_Id");
            AddForeignKey("dbo.Phones", "phone_Id", "dbo.Phones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "phone_Id", "dbo.Phones");
            DropIndex("dbo.Phones", new[] { "phone_Id" });
            DropColumn("dbo.Phones", "phone_Id");
        }
    }
}
