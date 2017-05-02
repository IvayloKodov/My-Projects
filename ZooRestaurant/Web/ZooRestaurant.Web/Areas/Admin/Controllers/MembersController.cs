namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Attributes;
    using Web.Controllers.Base;

    [MyAuthorize(Roles = "Admin")]
    public class MembersController : BaseController
    {
        [HttpGet]
        [Route("Admin/Members")]
        public ActionResult Members()
        {
            return this.View();
        }
    }
}