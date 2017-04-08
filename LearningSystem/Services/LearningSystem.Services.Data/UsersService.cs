namespace LearningSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using LearningSystem.Data.Common.Repositories;
    using LearningSystem.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Web.Models.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<IdentityRole> roles;

        public UsersService(IRepository<User> users, IRepository<IdentityRole> roles)
        {
            this.users = users;
            this.roles = roles;
        }

        public IQueryable<User> GetUsersByRoleName(string roleName)
        {
            var role = this.roles.All().FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                throw new InvalidOperationException("There is no such kind of role!");
            }

            return this.users.All().Where(u => u.Roles.Any(r => r.RoleId == role.Id));
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.users.All();
        }

        public User GetUserById(string id)
        {
            return this.users.GetById(id);
        }

        public IQueryable<string> GetUserRoleNames(User user)
        {
            var userRolesId = user.Roles.Select(r => r.RoleId);
            var userRoles = this.roles.All().Where(r => userRolesId.Contains(r.Id)).Select(r => r.Name);
            return userRoles;
        }

        public void EditUser(IMapper mapper, EditUserViewModel userVm)
        {
            var userDb = this.users.GetById(userVm.Id);
            mapper.Map(userVm, userDb);
            this.users.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var user = this.users.GetById(id);
            this.users.Delete(user);
            this.users.SaveChanges();
        }
    }
}