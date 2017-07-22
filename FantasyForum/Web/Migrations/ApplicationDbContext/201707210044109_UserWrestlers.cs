namespace Web.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserWrestlers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserWrestlers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        WrestlerId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Wrestlers", t => t.WrestlerId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WrestlerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWrestlers", "WrestlerId", "dbo.Wrestlers");
            DropForeignKey("dbo.UserWrestlers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserWrestlers", new[] { "WrestlerId" });
            DropIndex("dbo.UserWrestlers", new[] { "UserId" });
            DropTable("dbo.UserWrestlers");
        }
    }
}
