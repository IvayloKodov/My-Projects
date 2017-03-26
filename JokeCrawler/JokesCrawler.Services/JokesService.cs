namespace JokesCrawler.Services
{
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokes;

        public JokesService(IRepository<Joke> jokes)
        {
            this.jokes = jokes;
        }

        public void CreateJoke(Category category, string jokeContent)
        {
            var joke = new Joke()
            {
                Category = category,
                Content = jokeContent
            };

            this.jokes.Add(joke);
            this.jokes.SaveChanges();
        }
    }
}
