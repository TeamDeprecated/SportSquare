using System.Data.Entity.Migrations;

using SportSquare.Models;

namespace SportSquare.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SportSquareDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportSquareDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            var importer = new VenueImporter.VenueImporter();
            var venues = importer.ParseVenues();
            foreach (var venue in venues)
            {
                context.Set<Venue>().Add(venue);

            }
            context.SaveChanges();
        }
    }
}
