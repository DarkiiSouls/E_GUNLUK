namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFKfromTagsNote_remove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "tags_tagId", c => c.Int());
            CreateIndex("dbo.Notes", "tags_tagId");
            AddForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags", "tagId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags");
            DropIndex("dbo.Notes", new[] { "tags_tagId" });
            DropColumn("dbo.Notes", "tags_tagId");
        }
    }
}
