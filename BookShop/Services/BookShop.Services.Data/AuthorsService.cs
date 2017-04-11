namespace BookShop.Services.Data
{
    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using Contracts;

    public class AuthorsService : BaseService<Author>, IAuthorsService
    {
        public AuthorsService(IRepository<Author> dataSet) 
            : base(dataSet)
        {
        }
        
    }
}
