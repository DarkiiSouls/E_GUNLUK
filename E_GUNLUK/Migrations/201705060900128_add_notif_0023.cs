namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_notif_0023 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserFrndNotifies", "Notification_Id", "dbo.FriendshipNotifications");
            DropForeignKey("dbo.UserFrndNotifies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserFrndNotifies", new[] { "Notification_Id" });
            DropIndex("dbo.UserFrndNotifies", new[] { "User_Id" });
            CreateTable(
                "dbo.UserFriendNotifies",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.FriendshipNotifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
            DropTable("dbo.UserFrndNotifies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserFrndNotifies",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Notif_Id = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        Notification_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.Notif_Id });
            
            DropForeignKey("dbo.UserFriendNotifies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFriendNotifies", "NotificationId", "dbo.FriendshipNotifications");
            DropIndex("dbo.UserFriendNotifies", new[] { "NotificationId" });
            DropIndex("dbo.UserFriendNotifies", new[] { "UserId" });
            DropTable("dbo.UserFriendNotifies");
            CreateIndex("dbo.UserFrndNotifies", "User_Id");
            CreateIndex("dbo.UserFrndNotifies", "Notification_Id");
            AddForeignKey("dbo.UserFrndNotifies", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserFrndNotifies", "Notification_Id", "dbo.FriendshipNotifications", "Id");
        }
    }
}
