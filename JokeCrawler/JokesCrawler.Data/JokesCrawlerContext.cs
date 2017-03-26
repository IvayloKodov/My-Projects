namespace JokesCrawler.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public class JokesCrawlerContext : DbContext, IJokesCrawlerContext
    {
        public JokesCrawlerContext()
            : base("name=JokesCrawlerContext")
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Joke> Jokes { get; set; }
    }
}