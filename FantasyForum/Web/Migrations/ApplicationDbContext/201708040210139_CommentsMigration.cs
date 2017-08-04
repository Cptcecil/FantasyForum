namespace Web.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsItems", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserWrestlers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserWrestlers", new[] { "UserId" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsItemId = c.Int(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Content = c.String(),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.NewsItems", t => t.NewsItemId, cascadeDelete: true)
                .Index(t => t.NewsItemId)
                .Index(t => t.CreatedById);
            
            AlterColumn("dbo.UserWrestlers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserWrestlers", "UserId");
            AddForeignKey("dbo.NewsItems", "CreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserWrestlers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWrestlers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewsItems", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "NewsItemId", "dbo.NewsItems");
            DropForeignKey("dbo.Comments", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.UserWrestlers", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "CreatedById" });
            DropIndex("dbo.Comments", new[] { "NewsItemId" });
            AlterColumn("dbo.UserWrestlers", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Comments");
            CreateIndex("dbo.UserWrestlers", "UserId");
            AddForeignKey("dbo.UserWrestlers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewsItems", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
