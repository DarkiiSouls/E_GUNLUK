namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostTagModel_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTags", "NoteId", "dbo.Notes");
            DropPrimaryKey("dbo.PostTags");
            AddColumn("dbo.PostTags", "PtId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PostTags", "PtId");
            AddForeignKey("dbo.PostTags", "NoteId", "dbo.Notes", "NoteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTags", "NoteId", "dbo.Notes");
            DropPrimaryKey("dbo.PostTags");
            DropColumn("dbo.PostTags", "PtId");
            AddPrimaryKey("dbo.PostTags", "NoteId");
            AddForeignKey("dbo.PostTags", "NoteId", "dbo.Notes", "NoteId");
        }
    }
}
