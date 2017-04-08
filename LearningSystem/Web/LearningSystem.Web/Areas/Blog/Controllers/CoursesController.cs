using System.Web.Mvc;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Data.Models;
    using Services.Data.Contracts;
    using Web.Controllers.Contracts;
    using System.Linq;
    using Models.ViewModels.Courses;

    public class CoursesController : BaseController
    {
        private readonly ICoursesService courses;
        private readonly IUsersService users;

        public CoursesController(ICoursesService courses, IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        // GET: Blog/Courses
        public ActionResult Add()
        {
            var trainers = this.users
                               .GetUsersByRoleName("Trainer")
                               .Select(t => new SelectListItem()
                               {
                                   Text = t.Name,
                                   Value = t.Id
                               });

            var courseVm = new CreateCourseViewModel { Trainers = trainers };

            return this.View(courseVm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateCourseViewModel courseVm)
        {
            if (this.ModelState.IsValid)
            {
                var newCourse = this.Mapper().Map<Course>(courseVm);
                this.courses.AddCourse(newCourse);
                return this.RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return this.View(courseVm);
        }
    }
}