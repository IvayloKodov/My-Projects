namespace LearningSystem.Web.Models.ViewModels.Roles
{
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RoleViewModel : IMapFrom<IdentityRole>, IHaveCustomMappings
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsUserRole { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<IdentityRole, RoleViewModel>()
                         .ForMember(rvm => rvm.RoleName, opt => opt.MapFrom(r => r.Name))
                         .ForMember(rvm => rvm.RoleId, opt => opt.MapFrom(r => r.Id));
        }
    }
}