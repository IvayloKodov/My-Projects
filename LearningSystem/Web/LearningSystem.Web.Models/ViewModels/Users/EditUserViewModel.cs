namespace LearningSystem.Web.Models.ViewModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Roles;

    public class EditUserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string[] UserRoles { get; set; }

        [Display(Name = "Roles")]
        public List<RoleViewModel> AllRoles { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, EditUserViewModel>()
                .ForMember(x => x.AllRoles, opt => opt.Ignore());
            
            //FROM IUserViewModel to User
            configuration.CreateMap<EditUserViewModel, User>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(um => um.UserRoles.Select(r => new IdentityUserRole()
                {
                    RoleId = r,
                    UserId = um.Id
                })));
        }
    }
}