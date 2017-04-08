namespace LearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using AutoMapper;
    using LearningSystem.Data.Models;
    using Web.Models.ViewModels.Users;

    public interface IUsersService
    {
        IQueryable<User> GetUsersByRoleName(string roleName);

        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        IQueryable<string> GetUserRoleNames(User user);

        void EditUser(IMapper mapper, EditUserViewModel userVm);

        void DeleteUserById(int id);
    }
}