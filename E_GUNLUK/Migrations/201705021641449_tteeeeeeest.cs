namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tteeeeeeest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags");
            DropIndex("dbo.Notes", new[] { "tags_tagId" });
            DropColumn("dbo.Notes", "tags_tagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "tags_tagId", c => c.Int());
            CreateIndex("dbo.Notes", "tags_tagId");
            AddForeignKey("dbo.Notes", "tags_tagId", "dbo.Tags", "tagId");
        }
    }
}
