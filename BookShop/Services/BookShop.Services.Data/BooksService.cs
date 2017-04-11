namespace BookShop.Services.Data
{
    using System.Linq;
    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using Contracts;

    public class BooksService : BaseService<Book>, IBooksService
    {
        public BooksService(IRepository<Book> dataSet)
            : base(dataSet)
        {
        }

        public IQueryable<Book> Search(string search, int searchTopBooks)
        {
            if (search == null)
            {
                return this.GetAll();
            }

            var books = this.GetAll()
                                .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                                .Take(searchTopBooks)
                                .OrderBy(b => b.Title);

            return books;
        }
    }
}