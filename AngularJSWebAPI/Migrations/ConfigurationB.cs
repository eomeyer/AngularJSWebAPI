namespace AngularJSWebAPI.Migrations
{
    using AngularJSWebAPI.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationB : DbMigrationsConfiguration<AngularJSWebAPI.Contexts.SqlDbContext>
    {
        public ConfigurationB()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularJSWebAPI.Contexts.SqlDbContext context)
        {
            context.Continents.AddOrUpdate(p => p.Name, new Continent { Id = 1, Name = "Africa" });
            context.Countries.AddOrUpdate(p => p.Name, new Country { ContinentId = 1, Id = 1, Name = "South Africa" });
            context.SaveChanges();
        }
    }
}
