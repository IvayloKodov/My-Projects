namespace CameraBzaar.Services.Data
{
    using System;
    using System.Linq;
    using CamBazaar.Data.Common.Repositories;
    using CamBazaar.Data.Models;
    using Contracts;

    public class CamerasService : ICamerasService
    {
        private readonly IRepository<Camera> cameras;

        public CamerasService(IRepository<Camera> cameras)
        {
            this.cameras = cameras;
        }

        public IQueryable<Camera> GetAll()
        {
            return this.cameras.All();
        }

        public Camera GetById(int id)
        {
            return this.cameras.GetById(id);
        }

        public void AddCamera(Camera camera)
        {
            if (camera == null && this.cameras.All().Any(c => c.Make == camera.Make && c.Model == camera.Model))
            {
                throw new InvalidOperationException("Camera is null or there is such camera in Db!");
            }

            this.cameras.Add(camera);
            this.cameras.SaveChanges();
        }
    }
}