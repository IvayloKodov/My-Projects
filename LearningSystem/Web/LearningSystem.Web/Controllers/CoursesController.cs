namespace LearningSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Courses;
    using Services.Data.Contracts;

    public class CoursesController : BaseController
    {
        private readonly ICoursesService courses;
        private readonly IUsersService users;
        private readonly IStudentsService students;

        public CoursesController(ICoursesService courses, IUsersService users, IStudentsService students)
        {
            this.courses = courses;
            this.users = users;
            this.students = students;
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

        [Authorize]
        public ActionResult Enroll(int courseid)
        {
            var currentStudentId = this.User.Identity.GetUserId();
            var student = this.students.GetStudentById(currentStudentId);

            this.courses.EnrollStudentInCourse(student, courseid);

            return this.RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}