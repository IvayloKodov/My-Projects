namespace BookShop.Server.Api.Models.Authors
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;

    public class AuthorResponceModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual IEnumerable<string> BooksTitles { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Author, AuthorResponceModel>()
                .ForMember(am => am.BooksTitles, opts => opts.MapFrom(a => a.Books.Select(b => b.Title)));
        }
    }
}