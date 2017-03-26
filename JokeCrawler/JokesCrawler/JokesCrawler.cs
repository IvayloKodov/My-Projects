namespace JokesCrawler
{
    using System;
    using AngleSharp;
    using Data.Models;
    using Services.Contracts;

    public class JokesCrawler
    {
        private readonly ICategoriesService categories;
        private readonly IJokesService jokes;

        public JokesCrawler(ICategoriesService categories, IJokesService jokes)
        {
            this.categories = categories;
            this.jokes = jokes;
        }

        public void Execute()
        {
            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);

            Console.Write("Loading ");

            for (int i = 1; i < 100; i++)
            {
                if (i % 4 == 0)
                {
                    Console.Write(".");
                }
                
                var url = $"http://vicove.com/vic-{i}";
                var document = browsingContext.OpenAsync(url).Result;
                var jokeContent = document.QuerySelector("#content_box .post-content").TextContent.Trim();

                if (string.IsNullOrWhiteSpace(jokeContent))
                {
                    continue;
                }

                var categoryName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();

                Category category = this.categories.GetExistingCategory(categoryName) ??
                                    this.categories.AddCategory(categoryName);

                this.jokes.CreateJoke(category, jokeContent);
            }

            Console.WriteLine();
        }
    }
}