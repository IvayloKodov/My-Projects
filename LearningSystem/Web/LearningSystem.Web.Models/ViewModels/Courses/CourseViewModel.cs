namespace LearningSystem.Web.Models.ViewModels.Courses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;

    public class CourseViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int CourseCurrentStudents { get; set; }

        public int MaxPossibleStudents { get; set; }

        public string TrainerId { get; set; }

        public virtual User Trainer { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Course, CourseViewModel>()
                .ForMember(cvm => cvm.CourseCurrentStudents, opt => opt.MapFrom(c => c.Students.Count))
                .ForMember(cvm => cvm.MaxPossibleStudents, opt => opt.MapFrom(c => c.MaxStudents));
        }
    }
}