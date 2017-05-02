namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFKintags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "whichNote", "dbo.Notes");
            DropIndex("dbo.Tags", new[] { "whichNote" });
            RenameColumn(table: "dbo.Tags", name: "whichNote", newName: "Note_NoteId");
            AlterColumn("dbo.Tags", "Note_NoteId", c => c.Int());
            CreateIndex("dbo.Tags", "Note_NoteId");
            AddForeignKey("dbo.Tags", "Note_NoteId", "dbo.Notes", "NoteId");
            DropColumn("dbo.Notes", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Tags", c => c.String());
            DropForeignKey("dbo.Tags", "Note_NoteId", "dbo.Notes");
            DropIndex("dbo.Tags", new[] { "Note_NoteId" });
            AlterColumn("dbo.Tags", "Note_NoteId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tags", name: "Note_NoteId", newName: "whichNote");
            CreateIndex("dbo.Tags", "whichNote");
            AddForeignKey("dbo.Tags", "whichNote", "dbo.Notes", "NoteId", cascadeDelete: true);
        }
    }
}
