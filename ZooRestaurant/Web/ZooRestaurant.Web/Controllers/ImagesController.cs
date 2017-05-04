namespace ZooRestaurant.Web.Controllers
{
    using System.Net;
    using System.Text;
    using System.Web.Mvc;
    using Data.Common.Repositories;
    using Data.Models;

    [RoutePrefix("Images")]
    public class ImagesController : Controller
    {
        private readonly IRepository<Image> images;

        public ImagesController(IRepository<Image> images)
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