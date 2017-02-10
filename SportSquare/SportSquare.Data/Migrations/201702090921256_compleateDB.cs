namespace SportSquare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compleateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        WebAddress = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFavoriteVenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.UserWishVanues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Comment_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.UserFavoriteVenueUsers",
                c => new
                    {
                        UserFavoriteVenue_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
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
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rating_Id, t.User_Id })
                .ForeignKey("dbo.Ratings", t => t.Rating_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Rating_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserWishVanueUsers",
                c => new
                    {
                        UserWishVanue_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserWishVanue_Id, t.User_Id })
                .ForeignKey("dbo.UserWishVanues", t => t.UserWishVanue_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserWishVanue_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Comments", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.UserWishVanueUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserWishVanueUsers", "UserWishVanue_Id", "dbo.UserWishVanues");
            DropForeignKey("dbo.RatingUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RatingUsers", "Rating_Id", "dbo.Ratings");
            DropForeignKey("dbo.UserFavoriteVenueUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteVenueUsers", "UserFavoriteVenue_Id", "dbo.UserFavoriteVenues");
            DropForeignKey("dbo.UserComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.UserComments", "User_Id", "dbo.Users");
            DropIndex("dbo.UserWishVanueUsers", new[] { "User_Id" });
            DropIndex("dbo.UserWishVanueUsers", new[] { "UserWishVanue_Id" });
            DropIndex("dbo.RatingUsers", new[] { "User_Id" });
            DropIndex("dbo.RatingUsers", new[] { "Rating_Id" });
            DropIndex("dbo.UserFavoriteVenueUsers", new[] { "User_Id" });
            DropIndex("dbo.UserFavoriteVenueUsers", new[] { "UserFavoriteVenue_Id" });
            DropIndex("dbo.UserComments", new[] { "Comment_Id" });
            DropIndex("dbo.UserComments", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "VenueId" });
            DropIndex("dbo.Comments", new[] { "VenueId" });
            DropTable("dbo.UserWishVanueUsers");
            DropTable("dbo.RatingUsers");
            DropTable("dbo.UserFavoriteVenueUsers");
            DropTable("dbo.UserComments");
            DropTable("dbo.UserWishVanues");
            DropTable("dbo.Ratings");
            DropTable("dbo.UserFavoriteVenues");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Venues");
        }
    }
}
