namespace E_GUNLUK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        User = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.User);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
        }
    }
}
