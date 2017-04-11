namespace BookShop.Server.Api.Models.Books
{
    using Common.Mappings.Contracts;
    using Data.Models;

    public class SearchBookResponceModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}