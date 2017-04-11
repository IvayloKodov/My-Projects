namespace BookShop.Server.Common.Models.Books
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enums;
    using Mappings.Contracts;

    public class AddBookRequestModel : IMapFrom<Book>, IHaveCustomMappings
    {
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        [Range(0, 200)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public int AuthorId { get; set; }

        public string CategoriesNames { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, AddBookRequestModel>()
                .ForMember(b => b.CategoriesNames, opts => opts.Ignore())
                .ReverseMap();
        }
    }
}