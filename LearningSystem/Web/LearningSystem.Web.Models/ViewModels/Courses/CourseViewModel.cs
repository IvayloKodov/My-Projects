namespace LearningSystem.Web.Models.ViewModels.Courses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Mappings.Contracts;
    using Data.Models;

    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        public virtual User Trainer { get; set; }
    }
}