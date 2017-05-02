namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appuserrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "NoteTaker_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "NoteTaker_Id" });
            AlterColumn("dbo.Notes", "NoteTaker_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Notes", "NoteTaker_Id");
            AddForeignKey("dbo.Notes", "NoteTaker_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "NoteTaker_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "NoteTaker_Id" });
            AlterColumn("dbo.Notes", "NoteTaker_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notes", "NoteTaker_Id");
            AddForeignKey("dbo.Notes", "NoteTaker_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
