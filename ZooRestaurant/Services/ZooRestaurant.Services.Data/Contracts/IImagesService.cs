namespace ZooRestaurant.Services.Data.Contracts
{
    using ZooRestaurant.Data.Models;

    public interface IImagesService : IBaseService<Image>
    {
        Image GetDefaultImage();
    }
}