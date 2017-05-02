namespace ZooRestaurant.Web.Models.ViewModels.Messages
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MessageViewModel : IMapFrom<MessageViewModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Поща")]
        public string Email { get; set; }

        [Display(Name = "Тема")]
        public MessageSubjectType Subject { get; set; }

        [Display(Name = "Съобщение")]
        public string Content { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ReverseMap()
                .ForMember(m => m.SendDate, opts => opts.MapFrom(mvm => DateTime.Now));
        }
    }
}