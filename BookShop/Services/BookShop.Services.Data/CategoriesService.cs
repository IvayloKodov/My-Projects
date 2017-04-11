namespace BookShop.Services.Data
{
    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using Contracts;

    public class CategoriesService : BaseService<Category>, ICategoriesService
    {
        public CategoriesService(IRepository<Category> dataSet)
            : base(dataSet)
        {
        }
    }
}