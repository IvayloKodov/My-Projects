namespace LearningSystem.Web.Models.ViewModels.Courses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Common.Mappings.Contracts;
    using Data.Models;

    public class CreateCourseViewModel : IMapFrom<Course>, IHaveCustomMappings
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

        [Display(Name = "Trainer")]
        public IEnumerable<SelectListItem> Trainers { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Course, CreateCourseViewModel>()
                .ForMember(cvm => cvm.TrainerId, opt => opt.MapFrom(c => c.TrainerId))
                .ReverseMap();
        }
    }
}