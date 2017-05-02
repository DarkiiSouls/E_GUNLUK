namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MEH_234 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notes", name: "tag_tagId", newName: "Selected_tag_tagId");
            RenameIndex(table: "dbo.Notes", name: "IX_tag_tagId", newName: "IX_Selected_tag_tagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notes", name: "IX_Selected_tag_tagId", newName: "IX_tag_tagId");
            RenameColumn(table: "dbo.Notes", name: "Selected_tag_tagId", newName: "tag_tagId");
        }
    }
}
