namespace BookShop.Server.Common.Models.Authors
{
    using AutoMapper;
    using Data.Models;
    using Mappings.Contracts;
    using Microsoft.Build.Framework;

    public class AuthorRequestModel : IMapFrom<Author>, IHaveCustomMappings
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Author, AuthorRequestModel>().ReverseMap();
        }
    }
}