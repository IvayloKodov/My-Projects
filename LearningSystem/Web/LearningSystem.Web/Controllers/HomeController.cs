using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    using System.Linq;
    using Common.Mappings.Extensions;
    using Models.ViewModels.Courses;
    using Services.Data.Contracts;

    public class HomeController : Controller
    {
        private readonly ICoursesService courses;

        public HomeController(ICoursesService courses)
        {
            this.courses = courses;
        }

        public ActionResult Index()
        {
            var allCourses = this.courses.GetAllCourses()
                                 .OrderByDescending(c => c.EndDate)
                                 .To<CourseViewModel>()
                                 .ToList();

            return this.View(allCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}