namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}