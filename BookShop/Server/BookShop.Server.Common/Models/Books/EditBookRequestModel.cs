namespace BookShop.Server.Common.Models.Books
{
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enums;
    using Mappings.Contracts;

    public class EditBookRequestModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public int AuthorId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, EditBookRequestModel>().ReverseMap();
        }
    }
}