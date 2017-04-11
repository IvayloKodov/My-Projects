namespace BookShop.Server.Common.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Mappings.Contracts;

    public class CategoryRequestModel : IMapFrom<Category>, IHaveCustomMappings
    {
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryRequestModel>()
                .ForMember(c => c.Name, opts => opts.MapFrom(cm => cm.Name))
                .ReverseMap();
        }
    }
}