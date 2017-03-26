namespace JokesCrawler.Services.Contracts
{
    using Data.Models;

    public interface IJokesService
    {
        void CreateJoke(Category category, string jokeContent);
    }
}