namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.Common.Repositories;
    using Infrastructure.Mapping.Extensions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.ViewModels.Users;
    using Web.Controllers.Base;
    using WebGrease.Css.Extensions;
    using ZooRestaurant.Data.Models;

    public class MembersController : BaseController
    {
        private readonly IRepository<User> users;
        private readonly IRepository<IdentityRole> roles;

        public MembersController(IRepository<User> users, IRepository<IdentityRole> roles)
        {
            this.users = users;
            this.roles = roles;
        }

        // GET: Admin/Members
        public ActionResult Index()
        {
            var usersVms = this.users
                .All()
                .To<UserViewModel>()
                .ToList();

            return this.View(usersVms);
        }

        // GET: Admin/Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = this.users.GetById(id);

            if (user == null)
            {
                return this.HttpNotFound();
            }

            var userVm = this.Mapper.Map<UserViewModel>(user);
            return this.View(userVm);
        }

        // GET: Admin/Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = this.users.GetById(id);

            if (user == null)
            {
                return this.HttpNotFound();
            }
            var rolesListItems = this.roles
                                .All()
                                .ToList()
                                .Select(r => new SelectListItem()
                                {
                                    Value = r.Id,
                                    Text = r.Name
                                })
                                .ToList();

            if (rolesListItems.Any())
            {
                var userRolesIds = user.Roles.Select(r => r.RoleId);
                rolesListItems.Where(s => userRolesIds.Contains(s.Value)).ForEach(s => s.Selected = true);
            }

            var userVm = this.Mapper.Map<UserEditViewModel>(user);
            userVm.Roles = rolesListItems;

            return this.View(userVm);
        }

        // POST: Admin/Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditViewModel model)
        {
            var userDb = this.users.GetById(model.Id);

            if (this.ModelState.IsValid && userDb != null)
            {
                this.Mapper.Map(model, userDb);
                this.users.SaveChanges();
            }

            return this.View("Details", this.Mapper.Map<UserViewModel>(userDb));
        }

        // GET: Admin/Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = this.users.GetById(id);
            if (user == null)
            {
                return this.HttpNotFound();
            }
            return this.View(user);
        }

        // POST: Admin/Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = this.users.GetById(id);
            this.users.Delete(user);
            this.users.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.users.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
