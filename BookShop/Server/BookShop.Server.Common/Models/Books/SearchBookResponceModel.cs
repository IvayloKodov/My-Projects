namespace BookShop.Server.Common.Models.Books
{
    using Data.Models;
    using Mappings.Contracts;

    public class SearchBookResponceModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}