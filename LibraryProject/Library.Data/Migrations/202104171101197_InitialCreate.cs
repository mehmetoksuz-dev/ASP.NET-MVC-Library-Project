namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        RowNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                        Number = c.Int(nullable: false),
                        DateOfUpload = c.DateTime(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Writer", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Writer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BorrowBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        BringDate = c.DateTime(nullable: false),
                        BroughtDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Surname = c.String(nullable: false, maxLength: 50, unicode: false),
                        TcNo = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        PhoneNum = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        RegTime = c.DateTime(nullable: false),
                        Mail = c.String(maxLength: 80),
                        Pass = c.String(maxLength: 32, fixedLength: true, unicode: false),
                        Punishment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBook",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowBook", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Book", "WriterId", "dbo.Writer");
            DropForeignKey("dbo.CategoryBook", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.CategoryBook", "Category_Id", "dbo.Category");
            DropIndex("dbo.CategoryBook", new[] { "Book_Id" });
            DropIndex("dbo.CategoryBook", new[] { "Category_Id" });
            DropIndex("dbo.BorrowBook", new[] { "MemberId" });
            DropIndex("dbo.Book", new[] { "WriterId" });
            DropTable("dbo.CategoryBook");
            DropTable("dbo.Member");
            DropTable("dbo.BorrowBook");
            DropTable("dbo.Writer");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
        }
    }
}
