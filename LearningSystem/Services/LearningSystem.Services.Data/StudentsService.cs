namespace LearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using LearningSystem.Data.Common.Repositories;
    using LearningSystem.Data.Models;

    public class StudentsService : IStudentsService
    {
        private readonly IRepository<Student> students;

        public StudentsService(IRepository<Student> students)
        {
            this.students = students;
        }

        public Student GetStudentById(string userId)
        {
            return this.students.All().FirstOrDefault(s=>s.UserId==userId);
        }

        public void Delete(int studentId)
        {
            this.students.Delete(studentId);
            this.students.SaveChanges();
        }

        public void Create(string userId)
        {
            var student = new Student() { UserId = userId };
            this.students.Add(student);
            this.students.SaveChanges();
        }
    }
}