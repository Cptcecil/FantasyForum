namespace Web.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WrestlerStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wrestlers", "DefenseHead", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "DefenseBody", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "DefenseArms", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "DefenseLegs", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "DefenseFlying", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "OffenseHead", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "OffenseBody", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "OffenseArms", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "OffenseLegs", c => c.Int(nullable: false));
            AddColumn("dbo.Wrestlers", "OffenseFlying", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wrestlers", "OffenseFlying");
            DropColumn("dbo.Wrestlers", "OffenseLegs");
            DropColumn("dbo.Wrestlers", "OffenseArms");
            DropColumn("dbo.Wrestlers", "OffenseBody");
            DropColumn("dbo.Wrestlers", "OffenseHead");
            DropColumn("dbo.Wrestlers", "DefenseFlying");
            DropColumn("dbo.Wrestlers", "DefenseLegs");
            DropColumn("dbo.Wrestlers", "DefenseArms");
            DropColumn("dbo.Wrestlers", "DefenseBody");
            DropColumn("dbo.Wrestlers", "DefenseHead");
        }
    }
}
