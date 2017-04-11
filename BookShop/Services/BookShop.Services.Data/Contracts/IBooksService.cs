namespace BookShop.Services.Data.Contracts
{
    using System.Linq;
    using BookShop.Data.Models;

    public interface IBooksService : IBaseService<Book>
    {
        IQueryable<Book> Search(string search, int searchTopBooks);
    }
}