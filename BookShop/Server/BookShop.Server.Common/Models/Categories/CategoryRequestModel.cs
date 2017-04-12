namespace BookShop.Server.Common.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Constants;
    using Data.Models;
    using Mappings.Contracts;

    public class CategoryRequestModel : IMapFrom<Category>, IHaveCustomMappings
    {
        [StringLength(GlobalConstants.CategoryNameMaxLength,
        MinimumLength = GlobalConstants.CategoryNameMinLength)]
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryRequestModel>().ReverseMap();
        }
    }
}