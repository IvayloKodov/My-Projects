namespace JokesCrawler.Services.Contracts
{
    using Data.Models;

    public interface ICategoriesService 
    {
        bool Exists(string categoryName);

        Category AddCategory(string categoryName);
        
        Category GetExistingCategory(string categoryName);
    }
}