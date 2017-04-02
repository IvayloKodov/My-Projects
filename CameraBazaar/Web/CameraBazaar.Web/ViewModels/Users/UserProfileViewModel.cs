namespace CameraBazaar.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using CamBazaar.Data.Models;
    using Cameras;
    using Common.Mappings;
    using Common.Mappings.Contracts;

    public class UserProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<CameraViewModel> Cameras { get; set; }

        public int CamerasInStock { get; set; }

        public int CamerasOutOfStock { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserProfileViewModel>()
                .ForMember(cm => cm.CamerasInStock, opt => opt.MapFrom(c => c.Cameras.Count(ca => ca.IsInStock)))
                .ForMember(cm => cm.CamerasOutOfStock, opt => opt.MapFrom(c => c.Cameras.Count(ca => !ca.IsInStock)));
        }
    }
}