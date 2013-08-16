namespace RajeevMVCApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RajeevMVCApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RajeevMVCApp.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RajeevMVCApp.Models.UsersContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.UserProfiles.AddOrUpdate(
              p => p.UserName,
              new UserProfile { UserName = "az-sa" }
            );
             
        }
    }
}
