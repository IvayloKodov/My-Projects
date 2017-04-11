namespace BookShop.Server.Api.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;
    using Data.Models.Enums;

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

        public string CategoriesNames { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            List<Category> categoriesEntities = null;

            configuration.CreateMap<AddBookRequestModel, Book>()
                .ForMember(b => b.Categories,
                opts => opts.MapFrom(bm => bm.CategoriesNames.Split(' ')
                                            .Select(b => categoriesEntities.FirstOrDefault(c => c.Name == b))));
        }
    }
}