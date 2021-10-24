namespace CodeWork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "SearchText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "SearchText");
        }
    }
}
