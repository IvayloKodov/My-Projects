namespace ZooRestaurant.Services.Data
{
    using System.IO;
    using System.Reflection;
    using Base;
    using Contracts;
    using Web.Common.Helpers;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class ImagesService : BaseService<Image>, IImagesService
    {
        public ImagesService(IRepository<Image> dataSet)
            : base(dataSet)
        {
        }

        public Image GetDefaultImage()
        {
            var imagePath = "Content/Images/profileImage.png";
            var defaultImageContent = File.ReadAllBytes(PathHelper.MapPath(imagePath, Assembly.GetExecutingAssembly()));
            var image = new Image() {Content = defaultImageContent,FileExtension = "png"};
            return image;
        }
    }
}