namespace ZooRestaurant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.AddressModels;
    using Web.Common.Constants;

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
            this.CreateRoles(context);
            this.CreateAdminUser(context);
        }

        private void SeedTownAndNeighborhoods(string townNameCyrilic, string townNameLatin, ZooRestaurantContext context)
        {
            if (!context.Towns.Any(t => t.Name == townNameCyrilic))
            {
                var sofiaNeighborhoods =
                     File.ReadAllLines($"../../Resources/{townNameLatin}Neighborhoods.txt")
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

        private void CreateRoles(ZooRestaurantContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = RolesType.Admin }
                                                 , new IdentityRole { Name = RolesType.Customer }
                                                 , new IdentityRole { Name = RolesType.Dispatcher });

            context.SaveChanges();
        }

        private void CreateAdminUser(ZooRestaurantContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var user = new User()
                {
                    FirstName = "Ivaylo",
                    LastName = "Kodov",
                    UserName = "Ifaka",
                    PhoneNumber = "0897903353",
                    Email = "ivo@abv.bg"
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, RolesType.Admin);

                context.SaveChanges();
            }
        }

        private Image GetSampleImage()
        {
            var fileName = String.Empty;
            var file = File.ReadAllBytes("Migrations/Resources/Images/" + fileName);

            var image = new Image()
            {
                Content = file,
                FileExtension = "jpg"
            };

            return image;
        }
    }
}
