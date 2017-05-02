namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsinnote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Tags");
        }
    }
}
