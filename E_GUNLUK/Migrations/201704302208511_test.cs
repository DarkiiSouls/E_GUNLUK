namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        whichNote = c.Int(nullable: false),
                        theComment = c.String(nullable: false),
                        commentDate = c.DateTime(nullable: false),
                        commentator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.AspNetUsers", t => t.commentator_Id, cascadeDelete: true)
                .ForeignKey("dbo.Notes", t => t.whichNote, cascadeDelete: true)
                .Index(t => t.whichNote)
                .Index(t => t.commentator_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        NoteText = c.String(nullable: false),
                        NoteDate = c.DateTime(nullable: false),
                        PubOrPvt = c.Boolean(nullable: false),
                        NoteTaker_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.AspNetUsers", t => t.NoteTaker_Id, cascadeDelete: false)
                .Index(t => t.NoteTaker_Id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        whichNote = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.whichNote)
                .ForeignKey("dbo.Notes", t => t.whichNote)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.whichNote)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.FriendsLists",
                c => new
                    {
                        frindshipID = c.Int(nullable: false, identity: true),
                        friend_user_Id = c.String(maxLength: 128),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.frindshipID)
                .ForeignKey("dbo.AspNetUsers", t => t.friend_user_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.friend_user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        whichNote = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.whichNote)
                .ForeignKey("dbo.Notes", t => t.whichNote)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.whichNote)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        tagId = c.Int(nullable: false, identity: true),
                        whichNote = c.Int(nullable: false),
                        tag = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.tagId)
                .ForeignKey("dbo.Notes", t => t.whichNote, cascadeDelete: true)
                .Index(t => t.whichNote);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "whichNote", "dbo.Notes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Likes", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "whichNote", "dbo.Notes");
            DropForeignKey("dbo.FriendsLists", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendsLists", "friend_user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "whichNote", "dbo.Notes");
            DropForeignKey("dbo.Comments", "whichNote", "dbo.Notes");
            DropForeignKey("dbo.Notes", "NoteTaker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "commentator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "whichNote" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Likes", new[] { "user_Id" });
            DropIndex("dbo.Likes", new[] { "whichNote" });
            DropIndex("dbo.FriendsLists", new[] { "user_Id" });
            DropIndex("dbo.FriendsLists", new[] { "friend_user_Id" });
            DropIndex("dbo.Favorites", new[] { "user_Id" });
            DropIndex("dbo.Favorites", new[] { "whichNote" });
            DropIndex("dbo.Notes", new[] { "NoteTaker_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "commentator_Id" });
            DropIndex("dbo.Comments", new[] { "whichNote" });
            DropTable("dbo.Tags");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Likes");
            DropTable("dbo.FriendsLists");
            DropTable("dbo.Favorites");
            DropTable("dbo.Notes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
