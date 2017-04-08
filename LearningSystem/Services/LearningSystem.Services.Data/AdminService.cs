namespace LearningSystem.Services.Data
{
    using Contracts;
    using System.Linq;
    using AutoMapper;
    using Web.Common.Mappings.Extensions;
    using Web.Models.ViewModels.Roles;
    using Web.Models.ViewModels.Users;

    public class AdminService : IAdminService
    {
        private readonly IRolesService roles;
        private readonly IUsersService users;

        public AdminService(IRolesService roles, IUsersService users)
        {
            this.roles = roles;
            this.users = users;
        }

        public EditUserViewModel GetEditUserVm(IMapper mapper, string id)
        {
            var userDb = this.users.GetUserById(id);
            var userRoleNames = this.users.GetUserRoleNames(userDb);
            var allRolesVm = this.roles.GetAllRoles().To<RoleViewModel>().ToList();
            foreach (var roleViewModel in allRolesVm)
            {
                roleViewModel.IsUserRole = userRoleNames.Contains(roleViewModel.RoleName);
            }
            var editUserVm = mapper.Map<EditUserViewModel>(userDb);
            editUserVm.AllRoles = allRolesVm;

            return editUserVm;
        }
    }
}