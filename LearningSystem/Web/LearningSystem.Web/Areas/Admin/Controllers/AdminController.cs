using System.Web.Mvc;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Common.Mappings.Extensions;
    using Common.RoleConstans;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Users;
    using Services.Data.Contracts;
    using Web.Controllers.Contracts;

    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        private readonly IAdminService admin;
        private readonly IUsersService users;
        private readonly IStudentsService students;
        private readonly ApplicationUserManager _userManager;


        public AdminController(ApplicationUserManager userManager)
        {
            this._userManager = userManager;
        }

        public AdminController(IAdminService admin, IUsersService users, IStudentsService students)
        {
            this.admin = admin;
            this.users = users;
            this.students = students;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult ManageRoles()
        {
            var usersVm = this.users
                            .GetAllUsers()
                            .To<EditUserViewModel>();

            return this.View(usersVm);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var editUserVm = this.admin.GetEditUserVm(this.Mapper(), id);

            return this.View(editUserVm);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel userVm)
        {
            if (this.ModelState.IsValid)
            {
                this.users.EditUser(this.Mapper(), userVm);
                return this.RedirectToAction("Index");
            }

            return this.View(userVm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.users.DeleteUserById(id);

            return this.RedirectToAction("Index");
        }
    }
}