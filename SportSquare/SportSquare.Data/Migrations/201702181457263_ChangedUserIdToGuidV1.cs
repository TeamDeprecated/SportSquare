namespace SportSquare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserIdToGuidV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFavoriteVenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        WebAddress = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenueTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWishVenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFavoriteVenueUsers",
                c => new
                    {
                        UserFavoriteVenue_Id = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserFavoriteVenue_Id, t.User_Id })
                .ForeignKey("dbo.UserFavoriteVenues", t => t.UserFavoriteVenue_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserFavoriteVenue_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RatingUsers",
                c => new
                    {
                        Rating_Id = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rating_Id, t.User_Id })
                .ForeignKey("dbo.Ratings", t => t.Rating_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Rating_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.VenueTypeVenues",
                c => new
                    {
                        VenueType_Id = c.Int(nullable: false),
                        Venue_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VenueType_Id, t.Venue_Id })
                .ForeignKey("dbo.VenueTypes", t => t.VenueType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.Venue_Id, cascadeDelete: true)
                .Index(t => t.VenueType_Id)
                .Index(t => t.Venue_Id);
            
            CreateTable(
                "dbo.UserWishVenueUsers",
                c => new
                    {
                        UserWishVenue_Id = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserWishVenue_Id, t.User_Id })
                .ForeignKey("dbo.UserWishVenues", t => t.UserWishVenue_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserWishVenue_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWishVenueUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserWishVenueUsers", "UserWishVenue_Id", "dbo.UserWishVenues");
            DropForeignKey("dbo.VenueTypeVenues", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.VenueTypeVenues", "VenueType_Id", "dbo.VenueTypes");
            DropForeignKey("dbo.Ratings", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Comments", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.RatingUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RatingUsers", "Rating_Id", "dbo.Ratings");
            DropForeignKey("dbo.UserFavoriteVenueUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteVenueUsers", "UserFavoriteVenue_Id", "dbo.UserFavoriteVenues");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.UserWishVenueUsers", new[] { "User_Id" });
            DropIndex("dbo.UserWishVenueUsers", new[] { "UserWishVenue_Id" });
            DropIndex("dbo.VenueTypeVenues", new[] { "Venue_Id" });
            DropIndex("dbo.VenueTypeVenues", new[] { "VenueType_Id" });
            DropIndex("dbo.RatingUsers", new[] { "User_Id" });
            DropIndex("dbo.RatingUsers", new[] { "Rating_Id" });
            DropIndex("dbo.UserFavoriteVenueUsers", new[] { "User_Id" });
            DropIndex("dbo.UserFavoriteVenueUsers", new[] { "UserFavoriteVenue_Id" });
            DropIndex("dbo.Ratings", new[] { "VenueId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "VenueId" });
            DropTable("dbo.UserWishVenueUsers");
            DropTable("dbo.VenueTypeVenues");
            DropTable("dbo.RatingUsers");
            DropTable("dbo.UserFavoriteVenueUsers");
            DropTable("dbo.UserWishVenues");
            DropTable("dbo.VenueTypes");
            DropTable("dbo.Venues");
            DropTable("dbo.Ratings");
            DropTable("dbo.UserFavoriteVenues");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
