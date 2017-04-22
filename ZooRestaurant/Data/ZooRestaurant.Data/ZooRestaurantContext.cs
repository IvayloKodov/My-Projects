namespace ZooRestaurant.Data
{
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

        public virtual IDbSet<Meal> Meals { get; set; }

        public static ZooRestaurantContext Create()
        {
            return new ZooRestaurantContext();
        }
    }
}