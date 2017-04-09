namespace LearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using LearningSystem.Data.Models;

    public interface ICoursesService
    {
        IQueryable<Course> GetAllCourses();

        void AddCourse(Course newCourse);

        void EnrollStudentInCourse(Student student, int courseid);
    }
}