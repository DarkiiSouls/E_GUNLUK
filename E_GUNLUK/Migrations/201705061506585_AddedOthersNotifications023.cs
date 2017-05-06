namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOthersNotifications023 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentsNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotifyDate = c.DateTime(nullable: false),
                        Comment_commentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_commentId, cascadeDelete: true)
                .Index(t => t.Comment_commentId);
            
            CreateTable(
                "dbo.UserCommentsNotifies",
                c => new
                    {
                        UserId = c.String(maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.CommentsNotifications", t => t.NotificationId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCommentsNotifies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCommentsNotifies", "NotificationId", "dbo.CommentsNotifications");
            DropForeignKey("dbo.CommentsNotifications", "Comment_commentId", "dbo.Comments");
            DropIndex("dbo.UserCommentsNotifies", new[] { "NotificationId" });
            DropIndex("dbo.UserCommentsNotifies", new[] { "UserId" });
            DropIndex("dbo.CommentsNotifications", new[] { "Comment_commentId" });
            DropTable("dbo.UserCommentsNotifies");
            DropTable("dbo.CommentsNotifications");
        }
    }
}
