namespace ZooRestaurant.Web.Models.ViewModels.Messages
{
    using System;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MessagePartViewModel : IMapFrom<Message>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public MessageSubjectType Subject { get; set; }

        public DateTime SendDate { get; set; }
    }
}