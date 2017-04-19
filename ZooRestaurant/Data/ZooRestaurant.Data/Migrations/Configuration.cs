namespace ZooRestaurant.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Models.CustomerAddressModels;
    using static Web.Common.Helpers.PathHelper;

    public sealed class Configuration : DbMigrationsConfiguration<ZooRestaurantContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ZooRestaurantContext context)
        {
            if (!context.Towns.Any(t => t.TownName == "�����"))
            {
                var sofiaNeighborhoods =
                     File.ReadAllLines(MapPath("../../Resources/SofiaNeighborhoods.txt"))
                     .Select(t => t.Trim()).ToList();

                var sofia = new Town() { TownName = "�����" };
                context.Towns.Add(sofia);
                context.SaveChanges();

                var city = context.Towns.FirstOrDefault(t => t.TownName == "�����");
                foreach (var neighborhood in sofiaNeighborhoods)
                {
                    context.Neighborhoods.Add(new Neighborhood() { Name = neighborhood, TownId = city.Id});
                }
            }
        }
    }
}
