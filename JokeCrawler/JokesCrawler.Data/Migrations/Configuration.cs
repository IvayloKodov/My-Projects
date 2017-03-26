namespace JokesCrawler.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<JokesCrawler.Data.JokesCrawlerContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(JokesCrawlerContext context)
        {
        }
    }
}
