namespace SportSquare.Data.Migrations
{
    using EF.Model;
    using SportSquare.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VenueImporter;

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

            var importer = new VenueImporter();
            var venues = importer.ParseVenues();
            foreach (var venue in venues)
            {
                context.Set<Venue>().Add(venue);

            }
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
