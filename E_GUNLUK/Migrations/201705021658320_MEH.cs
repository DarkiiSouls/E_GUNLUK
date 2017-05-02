namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MEH : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notes", name: "tags_tagId", newName: "tag_tagId");
            RenameIndex(table: "dbo.Notes", name: "IX_tags_tagId", newName: "IX_tag_tagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notes", name: "IX_tag_tagId", newName: "IX_tags_tagId");
            RenameColumn(table: "dbo.Notes", name: "tag_tagId", newName: "tags_tagId");
        }
    }
}
