namespace Masonic.Blue.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixchartermodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Charter", new[] { "BodyType_Id" });
            DropIndex("dbo.Charter", new[] { "LodgeType_Id" });
            DropColumn("dbo.Charter", "BodyTypeId");
            DropColumn("dbo.Charter", "LodgeTypeId");
            RenameColumn(table: "dbo.Charter", name: "BodyType_Id", newName: "BodyTypeId");
            RenameColumn(table: "dbo.Charter", name: "LodgeType_Id", newName: "LodgeTypeId");
            AlterColumn("dbo.Charter", "LodgeTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Charter", "BodyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Charter", "BodyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Charter", "LodgeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Charter", "LodgeTypeId");
            CreateIndex("dbo.Charter", "BodyTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Charter", new[] { "BodyTypeId" });
            DropIndex("dbo.Charter", new[] { "LodgeTypeId" });
            AlterColumn("dbo.Charter", "LodgeTypeId", c => c.Int());
            AlterColumn("dbo.Charter", "BodyTypeId", c => c.Int());
            AlterColumn("dbo.Charter", "BodyTypeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Charter", "LodgeTypeId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Charter", name: "LodgeTypeId", newName: "LodgeType_Id");
            RenameColumn(table: "dbo.Charter", name: "BodyTypeId", newName: "BodyType_Id");
            AddColumn("dbo.Charter", "LodgeTypeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Charter", "BodyTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Charter", "LodgeType_Id");
            CreateIndex("dbo.Charter", "BodyType_Id");
        }
    }
}
