namespace BookShop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class BookShopContext : IdentityDbContext<User>
    {
        public BookShopContext()
            : base("BookShopContext", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }
    }
}
