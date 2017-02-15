namespace SportSquare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedsets : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserWishVanues", newName: "UserWishVenues");
            RenameTable(name: "dbo.UserWishVanueUsers", newName: "UserWishVenueUsers");
            RenameColumn(table: "dbo.UserWishVenueUsers", name: "UserWishVanue_Id", newName: "UserWishVenue_Id");
            RenameIndex(table: "dbo.UserWishVenueUsers", name: "IX_UserWishVanue_Id", newName: "IX_UserWishVenue_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserWishVenueUsers", name: "IX_UserWishVenue_Id", newName: "IX_UserWishVanue_Id");
            RenameColumn(table: "dbo.UserWishVenueUsers", name: "UserWishVenue_Id", newName: "UserWishVanue_Id");
            RenameTable(name: "dbo.UserWishVenueUsers", newName: "UserWishVanueUsers");
            RenameTable(name: "dbo.UserWishVenues", newName: "UserWishVanues");
        }
    }
}
