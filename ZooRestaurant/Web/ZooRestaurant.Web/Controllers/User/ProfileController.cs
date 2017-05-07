namespace ZooRestaurant.Web.Controllers.User
{
    using System.Web.Mvc;
    using Base;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Profile;
    using Services.Data.Contracts;

    public class ProfileController : BaseController
    {
        private readonly IUsersService users;

        public ProfileController(IUsersService users)
        {
            this.users = users;
        }

        // GET: Profile
        [Route("Profile")]
        public ActionResult Index()
        {
            var currentUser = this.users.GetById(this.User.Identity.GetUserId());
            var profileVm = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.View("Profile", profileVm);
        }
    }
}