namespace LearningSystem.Services.Data.Contracts
{
    using LearningSystem.Data.Models;

    public interface IStudentsService
    {
        Student GetStudentById(string userId);

        void Delete(int studentId);

        void Create(string userId);
    }
}