namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFKintags000590 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Note_NoteId", "dbo.Notes");
            DropForeignKey("dbo.TagsNotesRels", "noteId", "dbo.Notes");
            DropForeignKey("dbo.TagsNotesRels", "tagId", "dbo.Tags");
            DropIndex("dbo.Tags", new[] { "Note_NoteId" });
            DropIndex("dbo.TagsNotesRels", new[] { "tagId" });
            DropIndex("dbo.TagsNotesRels", new[] { "noteId" });
            AddColumn("dbo.Notes", "tags_tagId", c => c.Int());
            CreateIndex("dbo.Notes", "tags_tagId");
            AddForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags", "tagId");
            DropColumn("dbo.Tags", "Note_NoteId");
            DropTable("dbo.TagsNotesRels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagsNotesRels",
                c => new
                    {
                        tagId = c.Int(nullable: false),
                        noteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tagId);
            
            AddColumn("dbo.Tags", "Note_NoteId", c => c.Int());
            DropForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags");
            DropIndex("dbo.Notes", new[] { "tags_tagId" });
            DropColumn("dbo.Notes", "tags_tagId");
            CreateIndex("dbo.TagsNotesRels", "noteId");
            CreateIndex("dbo.TagsNotesRels", "tagId");
            CreateIndex("dbo.Tags", "Note_NoteId");
            AddForeignKey("dbo.TagsNotesRels", "tagId", "dbo.Tags", "tagId");
            AddForeignKey("dbo.TagsNotesRels", "noteId", "dbo.Notes", "NoteId", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "Note_NoteId", "dbo.Notes", "NoteId");
        }
    }
}
