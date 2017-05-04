namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostTagModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notes", name: "Selected_tag_tagId", newName: "Tags_tagId");
            RenameIndex(table: "dbo.Notes", name: "IX_Selected_tag_tagId", newName: "IX_Tags_tagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notes", name: "IX_Tags_tagId", newName: "IX_Selected_tag_tagId");
            RenameColumn(table: "dbo.Notes", name: "Tags_tagId", newName: "Selected_tag_tagId");
        }
    }
}
