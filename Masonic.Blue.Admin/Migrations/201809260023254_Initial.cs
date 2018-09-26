namespace Masonic.Blue.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Charter",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LodgeTypeId = c.Guid(nullable: false),
                        BodyTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyType", t => t.BodyTypeId)
                .ForeignKey("dbo.LodgeType", t => t.LodgeTypeId)
                .Index(t => t.LodgeTypeId)
                .Index(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContactType = c.String(),
                        ContactInfo = c.String(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Charter_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charter", t => t.Charter_Id)
                .Index(t => t.Charter_Id);
            
            CreateTable(
                "dbo.LodgeType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CharterId = c.Guid(nullable: false),
                        MasonicBodies = c.String(),
                        Officer = c.Boolean(nullable: false),
                        Past = c.Boolean(nullable: false),
                        OfficerTitle = c.String(),
                        MasonicTitle = c.String(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Charter", t => t.CharterId)
                .Index(t => t.CharterId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Profile", "CharterId", "dbo.Charter");
            DropForeignKey("dbo.Profile", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Charter", "LodgeTypeId", "dbo.LodgeType");
            DropForeignKey("dbo.Contact", "Charter_Id", "dbo.Charter");
            DropForeignKey("dbo.Charter", "BodyTypeId", "dbo.BodyType");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Profile", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Profile", new[] { "CharterId" });
            DropIndex("dbo.Contact", new[] { "Charter_Id" });
            DropIndex("dbo.Charter", new[] { "BodyTypeId" });
            DropIndex("dbo.Charter", new[] { "LodgeTypeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Profile");
            DropTable("dbo.LodgeType");
            DropTable("dbo.Contact");
            DropTable("dbo.Charter");
            DropTable("dbo.BodyType");
        }
    }
}
