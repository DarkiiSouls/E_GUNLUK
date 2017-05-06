namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class herlrre : DbMigration
    {
        public override void Up()
        {
            /*
            DropForeignKey("dbo.UserNotifications", "Id", "dbo.Notifications");
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.UserNotifications", new[] { "Id" });
            DropTable("dbo.Notifications");
            DropTable("dbo.UserNotifications");
            */
        }
        
        public override void Down()
        {
            /*
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Id });
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        notif_date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserNotifications", "Id");
            CreateIndex("dbo.UserNotifications", "UserId");
            AddForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserNotifications", "Id", "dbo.Notifications", "Id", cascadeDelete: true);
            */
        }
    }
}
