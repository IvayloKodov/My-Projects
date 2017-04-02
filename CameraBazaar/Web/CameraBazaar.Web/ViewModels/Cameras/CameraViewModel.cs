namespace CameraBazaar.Web.ViewModels.Cameras
{
    using System.ComponentModel.DataAnnotations;
    using CamBazaar.Data.Models;
    using CamBazaar.Data.Models.ValidationAttributes;
    using Common.Enums;
    using Common.Mappings;
    using Common.Mappings.Contracts;

    public class CameraViewModel : IMapFrom<Camera>
    {
        public int Id { get; set; }

        public MakeType Make { get; set; }

        [StringLength(20)]
        [Model]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [UIHint("IsInStock")]
        public bool IsInStock { get; set; }

        public string ImageUrl { get; set; }
    }
}