namespace BookShop.Server.Common.Models.Categories
{
    using Data.Models;
    using Mappings.Contracts;

    public class CategoryResponceModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}