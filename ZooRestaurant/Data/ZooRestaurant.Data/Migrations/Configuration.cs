namespace ZooRestaurant.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Models.AddressModels;
    using static Web.Common.Helpers.PathHelper;

    public sealed class Configuration : DbMigrationsConfiguration<ZooRestaurantContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ZooRestaurantContext context)
        {
            this.SeedTownAndNeighborhoods("София", "Sofia", context);
            this.SeedTownAndNeighborhoods("Пловдив", "Plovdiv", context);
        }

        private void SeedTownAndNeighborhoods(string townNameCyrilic, string townNameLatin, ZooRestaurantContext context)
        {
            if (!context.Towns.Any(t => t.Name == townNameCyrilic))
            {
                var sofiaNeighborhoods =
                     File.ReadAllLines(MapPath($"../../Resources/{townNameLatin}Neighborhoods.txt"))
                     .Select(t => t.Trim()).ToList();

                var sofia = new Town() { Name = townNameCyrilic };
                context.Towns.Add(sofia);
                context.SaveChanges();

                var city = context.Towns.First(t => t.Name == townNameCyrilic);
                foreach (var neighborhood in sofiaNeighborhoods)
                {
                    context.Neighborhoods.Add(new Neighborhood() { Name = neighborhood, TownId = city.Id });
                }
            }
        }
    }
}
