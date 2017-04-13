namespace ZooRestaurant.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ZooRestaurantContext : IdentityDbContext<User>
    {
        public ZooRestaurantContext()
            : base("ZooRestaurantContext", throwIfV1Schema: false)
        {
        }

        public static ZooRestaurantContext Create()
        {
            return new ZooRestaurantContext();
        }
    }
}