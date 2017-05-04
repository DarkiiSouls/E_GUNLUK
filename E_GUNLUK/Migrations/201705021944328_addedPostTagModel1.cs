namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostTagModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        NoteId = c.Int(nullable: false),
                        tagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .ForeignKey("dbo.Tags", t => t.tagId, cascadeDelete: true)
                .Index(t => t.NoteId)
                .Index(t => t.tagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTags", "tagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "NoteId", "dbo.Notes");
            DropIndex("dbo.PostTags", new[] { "tagId" });
            DropIndex("dbo.PostTags", new[] { "NoteId" });
            DropTable("dbo.PostTags");
        }
    }
}
