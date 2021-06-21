namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_tableName_change : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Adminns", newName: "Admins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Admins", newName: "Adminns");
        }
    }
}
