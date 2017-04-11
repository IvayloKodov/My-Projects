namespace BookShop.Server.Api.Models.Authors
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;

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