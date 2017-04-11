namespace BookShop.Server.Common.Models.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enums;
    using Mappings.Contracts;

    public class BookResponceModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public string AuthorFullName { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BookResponceModel>()
                .ForMember(bm => bm.AuthorFullName,
                    opts => opts.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName))
                .ForMember(bm => bm.CategoryNames,
                    opts => opts.MapFrom(b => b.Categories.Select(c => c.Name)));
        }
    }
}
