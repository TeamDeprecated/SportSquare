namespace SportSquare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserComments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Ratings", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.VenueTypeVenues", "Venue_VenueId", "dbo.Venues");
            DropForeignKey("dbo.VenueTypeVenues", "VenueType_VenueTypeId", "dbo.VenueTypes");
            DropIndex("dbo.UserComments", new[] { "User_Id" });
            DropIndex("dbo.UserComments", new[] { "Comment_Id" });
            RenameColumn(table: "dbo.VenueTypeVenues", name: "VenueType_VenueTypeId", newName: "VenueType_Id");
            RenameColumn(table: "dbo.VenueTypeVenues", name: "Venue_VenueId", newName: "Venue_Id");
            RenameIndex(table: "dbo.VenueTypeVenues", name: "IX_VenueType_VenueTypeId", newName: "IX_VenueType_Id");
            RenameIndex(table: "dbo.VenueTypeVenues", name: "IX_Venue_VenueId", newName: "IX_Venue_Id");
            DropPrimaryKey("dbo.Venues");
            DropPrimaryKey("dbo.VenueTypes");
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.VenueTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Venues", "Id");
            AddPrimaryKey("dbo.VenueTypes", "Id");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "VenueId", "dbo.Venues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "VenueId", "dbo.Venues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueTypeVenues", "Venue_Id", "dbo.Venues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueTypeVenues", "VenueType_Id", "dbo.VenueTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Venues", "VenueId");
            DropColumn("dbo.Venues", "Title");
            DropColumn("dbo.Venues", "Description");
            DropColumn("dbo.VenueTypes", "VenueTypeId");
            DropTable("dbo.UserComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Comment_Id });
            
            AddColumn("dbo.VenueTypes", "VenueTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Venues", "Description", c => c.String());
            AddColumn("dbo.Venues", "Title", c => c.String());
            AddColumn("dbo.Venues", "VenueId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.VenueTypeVenues", "VenueType_Id", "dbo.VenueTypes");
            DropForeignKey("dbo.VenueTypeVenues", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.Ratings", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Comments", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropPrimaryKey("dbo.VenueTypes");
            DropPrimaryKey("dbo.Venues");
            DropColumn("dbo.VenueTypes", "Id");
            DropColumn("dbo.Venues", "Id");
            DropColumn("dbo.Comments", "IsDeleted");
            DropColumn("dbo.Comments", "UserId");
            AddPrimaryKey("dbo.VenueTypes", "VenueTypeId");
            AddPrimaryKey("dbo.Venues", "VenueId");
            RenameIndex(table: "dbo.VenueTypeVenues", name: "IX_Venue_Id", newName: "IX_Venue_VenueId");
            RenameIndex(table: "dbo.VenueTypeVenues", name: "IX_VenueType_Id", newName: "IX_VenueType_VenueTypeId");
            RenameColumn(table: "dbo.VenueTypeVenues", name: "Venue_Id", newName: "Venue_VenueId");
            RenameColumn(table: "dbo.VenueTypeVenues", name: "VenueType_Id", newName: "VenueType_VenueTypeId");
            CreateIndex("dbo.UserComments", "Comment_Id");
            CreateIndex("dbo.UserComments", "User_Id");
            AddForeignKey("dbo.VenueTypeVenues", "VenueType_VenueTypeId", "dbo.VenueTypes", "VenueTypeId", cascadeDelete: true);
            AddForeignKey("dbo.VenueTypeVenues", "Venue_VenueId", "dbo.Venues", "VenueId", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "VenueId", "dbo.Venues", "VenueId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "VenueId", "dbo.Venues", "VenueId", cascadeDelete: true);
            AddForeignKey("dbo.UserComments", "Comment_Id", "dbo.Comments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserComments", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
