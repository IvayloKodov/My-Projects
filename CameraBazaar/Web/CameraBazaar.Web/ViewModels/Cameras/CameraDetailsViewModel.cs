namespace CameraBazaar.Web.ViewModels.Cameras
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using CamBazaar.Data.Models;
    using CamBazaar.Data.Models.ValidationAttributes;
    using Common.Enums;
    using Common.Mappings;
    using Common.Mappings.Contracts;

    public class CameraDetailsViewModel : IMapFrom<Camera>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public MakeType Make { get; set; }

        [StringLength(20)]
        [Model]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        [Display(Name = "Min Shutter Speed")]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        [Display(Name = "Max Shutter Speed")]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        [Display(Name = "Min ISO")]
        public int MinIso { get; set; }

        [Range(200, 409600)]
        [Display(Name = "Max ISO")]
        public int MaxIso { get; set; }

        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }

        [StringLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public IEnumerable<LightMetering> LightMeterings { get; set; }

        [StringLength(6000)]
        public string Description { get; set; }

        [ImageUrl]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [UIHint("IsInStock")]
        public bool IsInStock { get; set; }

        public User Owner { get; set; }

        public IEnumerable<SelectListItem> AllMakes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Camera, CameraDetailsViewModel>()
                .ReverseMap();
        }
    }
}