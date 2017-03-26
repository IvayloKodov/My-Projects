namespace JokesCrawler.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IJokesCrawlerContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Joke> Jokes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}