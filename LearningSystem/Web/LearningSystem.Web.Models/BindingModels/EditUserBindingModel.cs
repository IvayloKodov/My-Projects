namespace LearningSystem.Web.Models.BindingModels
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EditUserBindingModel : IMapTo<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EditUserBindingModel, User>()
                 .ForMember(u => u.Roles, 
                 opt => opt.MapFrom(um => um.Roles.Select(r => new IdentityUserRole()
                                                                 {
                                                                     RoleId = r,
                                                                     UserId = um.Id
                                                                 })));
        }
    }
}