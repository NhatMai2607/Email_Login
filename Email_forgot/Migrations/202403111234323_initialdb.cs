namespace Email_forgot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Tbl_IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Tbl_IdentityRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tbl_ApplicationUser",
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
                "dbo.Tbl_IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tbl_IdentityUderLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Tbl_ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_IdentityUserRole", "UserId", "dbo.Tbl_ApplicationUser");
            DropForeignKey("dbo.Tbl_IdentityUderLogin", "UserId", "dbo.Tbl_ApplicationUser");
            DropForeignKey("dbo.Tbl_IdentityUserClaim", "UserId", "dbo.Tbl_ApplicationUser");
            DropForeignKey("dbo.Tbl_IdentityUserRole", "RoleId", "dbo.Tbl_IdentityRole");
            DropIndex("dbo.Tbl_IdentityUderLogin", new[] { "UserId" });
            DropIndex("dbo.Tbl_IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.Tbl_ApplicationUser", "UserNameIndex");
            DropIndex("dbo.Tbl_IdentityUserRole", new[] { "RoleId" });
            DropIndex("dbo.Tbl_IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.Tbl_IdentityRole", "RoleNameIndex");
            DropTable("dbo.Tbl_IdentityUderLogin");
            DropTable("dbo.Tbl_IdentityUserClaim");
            DropTable("dbo.Tbl_ApplicationUser");
            DropTable("dbo.Tbl_IdentityUserRole");
            DropTable("dbo.Tbl_IdentityRole");
        }
    }
}
