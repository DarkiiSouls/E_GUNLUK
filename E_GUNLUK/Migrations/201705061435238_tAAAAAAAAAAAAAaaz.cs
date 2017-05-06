namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tAAAAAAAAAAAAAaaz : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserFriendNotifies", "NotificationId", "dbo.FriendshipNotifications");
            DropPrimaryKey("dbo.UserFriendNotifies");
            AddPrimaryKey("dbo.UserFriendNotifies", "NotificationId");
            AddForeignKey("dbo.UserFriendNotifies", "NotificationId", "dbo.FriendshipNotifications", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFriendNotifies", "NotificationId", "dbo.FriendshipNotifications");
            DropPrimaryKey("dbo.UserFriendNotifies");
            AddPrimaryKey("dbo.UserFriendNotifies", new[] { "UserId", "NotificationId" });
            AddForeignKey("dbo.UserFriendNotifies", "NotificationId", "dbo.FriendshipNotifications", "Id", cascadeDelete: true);
        }
    }
}
