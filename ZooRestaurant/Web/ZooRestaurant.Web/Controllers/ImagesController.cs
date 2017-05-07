namespace ZooRestaurant.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data.Contracts;

    [RoutePrefix("Images")]
    public class ImagesController : Controller
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService images)
        {
            this.images = images;
        }

        [Route("GetImage")]
        public ActionResult GetImage(int id)
        {
            Image image = this.images.GetById(id);

            if (image == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}