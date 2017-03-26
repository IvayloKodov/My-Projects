namespace JokesCrawler.Services
{
    using System.Linq;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public bool Exists(string categoryName)
        {
            return this.categories.All().Any(c =>c.Name==categoryName);
        }

        public Category AddCategory(string categoryName)
        {
            var category = new Category {Name = categoryName};
            this.categories.Add(category);
            this.categories.SaveChanges();

            return category;
        }

        public Category GetExistingCategory(string categoryName)
        {
            return this.categories
                .All()
                .FirstOrDefault(c => c.Name == categoryName);
        }
    }
}