namespace CameraBzaar.Services.Data.Contracts
{
    using System.Linq;
    using CamBazaar.Data.Models;

    public interface ICamerasService
    {
        IQueryable<Camera> GetAll();

        Camera GetById(int id);

        void AddCamera(Camera camera);
    }
}