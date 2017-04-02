namespace CameraBazaar.Web
{
    using System.Data.Entity;
    using CamBazaar.Data;
    using CamBazaar.Data.Migrations;
    using Common.Constants;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            if (!Database.Exists(DatabaseConstants.ConnectionString))
            {
                new CameraBazaarContext().Database.Initialize(true);
            }

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CameraBazaarContext,Configuration>());
        }
    }
}