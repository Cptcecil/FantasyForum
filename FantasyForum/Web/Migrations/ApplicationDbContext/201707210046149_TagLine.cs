namespace Web.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TagLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TagLine");
        }
    }
}
