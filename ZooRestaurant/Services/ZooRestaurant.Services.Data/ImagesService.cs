namespace ZooRestaurant.Services.Data
{
    using Base;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class ImagesService : BaseService<Image>, IImagesService
    {
        public ImagesService(IRepository<Image> dataSet)
            : base(dataSet)
        {
        }


    }
}