namespace LearningSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private const int MaxStudentsCount = 100;
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.MaxStudents = MaxStudentsCount;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        public virtual User Trainer { get; set; }

        public int MaxStudents { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}