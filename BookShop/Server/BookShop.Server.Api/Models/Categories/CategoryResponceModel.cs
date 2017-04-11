namespace BookShop.Server.Api.Models.Categories
{
    using Common.Mappings.Contracts;
    using Data.Models;

    public class CategoryResponceModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}