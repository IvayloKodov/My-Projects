namespace LearningSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Web.Common.RoleConstans;

    public sealed class Configuration : DbMigrationsConfiguration<LearningSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(LearningSystemContext context)
        {
            this.AddRoles(context);
            this.AddAdinUser(context);
        }

        private void AddAdinUser(LearningSystemContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var user = new User()
            {
                Email = "ivo@abv.bg",
                UserName = "ifaka",
                PhoneNumber = "+235235235235",
                Name = "Ivaylo Kodov"
            };
            userManager.Create(user, "123456");

            userManager.AddToRole(user.Id, RoleType.Administrator.ToString());
            context.SaveChanges();
        }

        private void AddRoles(LearningSystemContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleType.Guest.ToString()))
            {
                roleManager.Create(new IdentityRole(RoleType.Guest.ToString()));
            }

            if (!roleManager.RoleExists(RoleType.Student.ToString()))
            {
                roleManager.Create(new IdentityRole(RoleType.Student.ToString()));
            }

            if (!roleManager.RoleExists(RoleType.Administrator.ToString()))
            {
                roleManager.Create(new IdentityRole(RoleType.Administrator.ToString()));
            }

            if (!roleManager.RoleExists(RoleType.BlogAuthor.ToString()))
            {
                roleManager.Create(new IdentityRole(RoleType.BlogAuthor.ToString()));
            }

            if (!roleManager.RoleExists(RoleType.Trainer.ToString()))
            {
                roleManager.Create(new IdentityRole(RoleType.Trainer.ToString()));
            }

            context.SaveChanges();
        }
    }
}
