namespace LearningSystem.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        private const string ConnectionString = "LearningSystemContext";

        public static void Initialize()
        {
            if (!Database.Exists(ConnectionString))
            {
               new LearningSystemContext().Database.Create();
            }
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LearningSystemContext, Configuration>());
        }
    }
}