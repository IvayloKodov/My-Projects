namespace CameraBazaar.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using CamBazaar.Data.Models;
    using CameraBzaar.Services.Data.Contracts;
    using Common.Mappings.Extensions;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using ViewModels.Cameras;

    [Authorize]
    [RoutePrefix("Cameras")]
    public class CamerasController : BaseController
    {
        private readonly ICamerasService cameras;

        public CamerasController(ICamerasService cameras, IIdentifierProvider provider)
            : base(provider)
        {
            this.cameras = cameras;
        }

        //GET: All Cameras
        [Route("All")]
        [AllowAnonymous]
        public ActionResult All()
        {
            var vms = this.cameras.GetAll().To<CameraViewModel>().ToList();
            return this.View(vms);
        }

        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [Route("Add")]
        [HttpPost]
        public ActionResult Add(CameraDetailsViewModel cameraVm)
        {
            if (this.ModelState.IsValid)
            {
                var camera = this.Mapper.Map<Camera>(cameraVm);
                camera.OwnerId = this.User.Identity.GetUserId();
                this.cameras.AddCamera(camera);
                return this.RedirectToAction("All");
            }

            return this.View(cameraVm);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var camera = this.cameras.GetById(id);
            var vm = this.Mapper.Map<CameraDetailsViewModel>(camera);

            return this.View(vm);
        }
    }
}