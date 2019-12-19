namespace FormosBar.Migrations.ContextB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigB : DbMigrationsConfiguration<FormosBar.DAL.BarContext>
    {
        public ConfigB()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContextB";
            ContextKey = "FormosBar.DAL.BarContext";
        }

        protected override void Seed(FormosBar.DAL.BarContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
