namespace ZooRestaurant.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Base;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class MembersService : BaseService<User>, IMembersService
    {
        private readonly IRepository<IdentityRole> roles;

        public MembersService(IRepository<User> dataSet, IRepository<IdentityRole> roles)
            : base(dataSet)
        {
            this.roles = roles;
        }

        public IEnumerable<SelectListItem> GetAllUserRoles(User user)
        {
            var userRolesItems = this.roles
                                .All()
                                .Select(r => new SelectListItem()
                                {
                                    Value = r.Id,
                                    Text = r.Name
                                })
                                .ToList();

            if (userRolesItems.Any())
            {
                var userRolesIds = user.Roles.Select(r => r.RoleId);
                userRolesItems.Where(s => userRolesIds.Contains(s.Value))
                              .ToList()
                              .ForEach(s => s.Selected = true);
            }

            return userRolesItems;
        }
    }
}