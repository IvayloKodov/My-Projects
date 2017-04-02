using System.Web.Mvc;

namespace CameraBazaar.Web.Controllers
{
    using CameraBzaar.Services.Data.Contracts;
    using Contracts;
    using ViewModels.Users;

    [RoutePrefix("Users")]
    public class UsersController : BaseController
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users, IIdentifierProvider provider)
            : base(provider)
        {
            this.users = users;
        }

        // GET: Users
        [Route("{id}")]
        public ActionResult UserProfile(string id)
        {
            var user = this.users.GetUserById(id);
            var vm = this.Mapper.Map<UserProfileViewModel>(user);

            return this.View(vm);
        }
    }
}