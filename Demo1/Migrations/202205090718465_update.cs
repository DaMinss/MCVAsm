namespace Demo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductMaster",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 50),
                        Publisher = c.String(maxLength: 50),
                        Description = c.String(),
                        CategoryID = c.Int(nullable: false),
                        BookPrice = c.Double(),
                        BookQuantity = c.Double(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductMaster", "CategoryID", "dbo.Category");
            DropIndex("dbo.ProductMaster", new[] { "CategoryID" });
            DropTable("dbo.ProductMaster");
            DropTable("dbo.Category");
        }
    }
}
