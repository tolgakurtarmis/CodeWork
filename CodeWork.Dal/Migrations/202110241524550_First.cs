namespace CodeWork.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            CreateIndex("dbo.Books", "BookAuthorId");
            AddForeignKey("dbo.Books", "BookAuthorId", "dbo.BookAuthors", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookAuthors", "Book_Id", c => c.Int());
            DropForeignKey("dbo.Books", "BookAuthorId", "dbo.BookAuthors");
            DropIndex("dbo.Books", new[] { "BookAuthorId" });
        }
    }
}
