namespace SportSquare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuidPropToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AspNetUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AspNetUserId");
        }
    }
}
