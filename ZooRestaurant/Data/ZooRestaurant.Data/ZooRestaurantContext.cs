namespace ZooRestaurant.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.AddressModels;

    public class ZooRestaurantContext : IdentityDbContext<User>
    {
        public ZooRestaurantContext()
            : base("ZooRestaurantContext", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Neighborhood> Neighborhoods { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<MealCategory> MealCategories { get; set; }

        public virtual IDbSet<Meal> Meals { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public static ZooRestaurantContext Create()
        {
            return new ZooRestaurantContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                        .HasRequired(s => s.Customer)
                        .WithRequiredDependent(c => c.ShoppingCart)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}