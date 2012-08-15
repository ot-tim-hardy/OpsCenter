namespace OpsCenter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OpsCenter.Models.OpsCenterDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OpsCenter.Models.OpsCenterDB context)
        {
			// This method will be called after migrating to the latest version.
			context.Configurations.AddOrUpdate(
				c => new { c.Environment, c.ConfigKey }, // This parm determines the columns to check for dupes 
				new Models.Configuration { Environment = "DEV", ConfigKey = "FavoriteColor", Value = "Blue" },
				new Models.Configuration { Environment = "DEV", ConfigKey = "Number", Value = "11" },
				new Models.Configuration { Environment = "DEV", ConfigKey = "Mode", Value = "Awesome" },
				new Models.Configuration { Environment = "QA", ConfigKey = "FavoriteColor", Value = "Yellow" },
				new Models.Configuration { Environment = "QA", ConfigKey = "Number", Value = "35" },
				new Models.Configuration { Environment = "QA", ConfigKey = "Mode", Value = "Mediocre" });
            
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
