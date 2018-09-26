namespace Masonic.Blue.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lodgeNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charter", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Charter", "Number");
        }
    }
}
