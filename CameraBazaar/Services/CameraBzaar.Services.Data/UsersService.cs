namespace CameraBzaar.Services.Data
{
    using CamBazaar.Data.Common.Repositories;
    using CamBazaar.Data.Models;
    using Contracts;

    public class UsersService :IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetUserById(string id)
        {
            return this.users.GetById(id);
        }
    }
}