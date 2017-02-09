namespace MitiankinContacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Phones", name: "PhoneType_Id", newName: "Type_Id");
            RenameIndex(table: "dbo.Phones", name: "IX_PhoneType_Id", newName: "IX_Type_Id");
            AddColumn("dbo.PhoneTypes", "TypeName", c => c.String());
            DropColumn("dbo.PhoneTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhoneTypes", "Type", c => c.String());
            DropColumn("dbo.PhoneTypes", "TypeName");
            RenameIndex(table: "dbo.Phones", name: "IX_Type_Id", newName: "IX_PhoneType_Id");
            RenameColumn(table: "dbo.Phones", name: "Type_Id", newName: "PhoneType_Id");
        }
    }
}
