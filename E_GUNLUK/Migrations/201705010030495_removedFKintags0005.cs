namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFKintags0005 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagsNotesRels",
                c => new
                    {
                        tagId = c.Int(nullable: false),
                        noteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tagId)
                .ForeignKey("dbo.Notes", t => t.noteId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.tagId)
                .Index(t => t.tagId)
                .Index(t => t.noteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsNotesRels", "tagId", "dbo.Tags");
            DropForeignKey("dbo.TagsNotesRels", "noteId", "dbo.Notes");
            DropIndex("dbo.TagsNotesRels", new[] { "noteId" });
            DropIndex("dbo.TagsNotesRels", new[] { "tagId" });
            DropTable("dbo.TagsNotesRels");
        }
    }
}
