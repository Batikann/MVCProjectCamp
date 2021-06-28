namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_userName_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterUserName");
        }
    }
}
