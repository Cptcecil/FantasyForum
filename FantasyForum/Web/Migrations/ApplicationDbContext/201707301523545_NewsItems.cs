namespace Web.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        Body = c.String(),
                        Headline = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: true)
                .Index(t => t.CreatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsItems", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.NewsItems", new[] { "CreatedById" });
            DropTable("dbo.NewsItems");
        }
    }
}
