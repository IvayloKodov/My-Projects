namespace LearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using LearningSystem.Data.Common.Repositories;
    using LearningSystem.Data.Models;

    public class CoursesService : ICoursesService
    {
        private readonly IRepository<Course> courses;

        public CoursesService(IRepository<Course> courses)
        {
            this.courses = courses;
        }

        public IQueryable<Course> GetAllCourses()
        {
            return this.courses.All();
        }

        public void AddCourse(Course newCourse)
        {
            this.courses.Add(newCourse);
            this.courses.SaveChanges();
        }

        public void EnrollStudentInCourse(Student student, int courseid)
        {
            if (student == null)
            {
                return;
            }

            var course = this.courses.GetById(courseid);

            if (course == null || course.MaxStudents + 1 > course.MaxStudents)
            {
                return;
            }

            course.Students.Add(student);
            this.courses.SaveChanges();
        }
    }
}
