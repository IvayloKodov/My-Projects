namespace ZooRestaurant.Web.Models.ViewModels.Profile
{
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class ProfileViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int ImageId { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}