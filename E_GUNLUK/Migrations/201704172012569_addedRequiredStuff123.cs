namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequiredStuff123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "theComment", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "NoteText", c => c.String(nullable: false));
            AlterColumn("dbo.Tags", "tag", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "tag", c => c.String());
            AlterColumn("dbo.Notes", "NoteText", c => c.String());
            AlterColumn("dbo.Comments", "theComment", c => c.String());
        }
    }
}
