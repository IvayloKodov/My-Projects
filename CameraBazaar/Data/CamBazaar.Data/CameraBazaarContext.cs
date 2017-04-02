namespace CamBazaar.Data
{
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class CameraBazaarContext : IdentityDbContext<User>
    {
        public CameraBazaarContext()
            : base("CameraBazaarContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Camera> Cameras { get; set; }

        public virtual DbSet<LightMetering> LightMeterings { get; set; }

        public static CameraBazaarContext Create()
        {
            return new CameraBazaarContext();
        }

        public override int SaveChanges()
        {
            var addModifiedCameras = this.ChangeTracker.Entries()
                              .Where(x => x.Entity is Camera &&
                                          (x.State == EntityState.Modified ||
                                          x.State == EntityState.Added));

            foreach (var entity in addModifiedCameras)
            {
                Camera camera = (Camera)entity.Entity;
                camera.IsInStock = camera.Quantity > 0;
            }

            return base.SaveChanges();
        }
    }
}
